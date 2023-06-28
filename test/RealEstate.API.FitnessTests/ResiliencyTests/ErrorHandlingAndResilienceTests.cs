using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.MSBuild;
using Shouldly;

namespace RealEstate.API.FitnessTests.DependencyConstraintTests
{
    public class ErrorHandlingAndResilienceTests
    {
        private string _apiProjectPath = "../../../../../src/API/RealEstateAPI/RealEstateAPI.csproj";

        [Fact]
        public void Application_Library_Refers_Domain_Library()
        {
            var errorHandlingAndResiliencyScore = CalculateErrorHandlingToNumberOfOperationsRatio();
            errorHandlingAndResiliencyScore.ShouldBeGreaterThan(0);
        }

        private double CalculateErrorHandlingToNumberOfOperationsRatio()
        {
            int totalEndpoints = 0;
            int endpointsWithErrorHandling = 0;

            var compilation = GetProject().GetCompilationAsync().Result;
            var syntaxTrees = compilation!.SyntaxTrees;

            foreach (var syntaxTree in syntaxTrees)
            {
                var root = syntaxTree.GetRoot();
                var classDeclarations = root.DescendantNodes().OfType<ClassDeclarationSyntax>();

                foreach (var classDeclaration in classDeclarations)
                {
                    var methodDeclarations = classDeclaration.DescendantNodes().OfType<MethodDeclarationSyntax>();

                    foreach (var methodDeclaration in methodDeclarations)
                    {
                        if (IsOperationMethod(methodDeclaration))
                        {
                            totalEndpoints++;

                            if (HasTryCatchBlock(methodDeclaration))
                                endpointsWithErrorHandling++;
                        }
                    }
                }
            }

            if (totalEndpoints == 0) return 0.0;

            return ((double)endpointsWithErrorHandling / totalEndpoints);
        }

        #region Helper Methods
        private Project GetProject()
        {
            using var workspace = MSBuildWorkspace.Create();
            var project = workspace.OpenProjectAsync(_apiProjectPath).Result;
            var projectFullName = Directory.GetParent(project.FilePath).FullName;
            var files = GetAllSourceFiles(projectFullName);
            var newProject = AddDocuments(project, files);
            return newProject;
        }

        private static IEnumerable<string> GetAllSourceFiles(string directoryPath) =>
            Directory.GetFiles(directoryPath, "*.cs", SearchOption.AllDirectories);

        private static Project AddDocuments(Project project, IEnumerable<string> files)
        {
            foreach (string file in files)
                project = project.AddDocument(file, File.ReadAllText(file)).Project;

            return project;
        }

        private static bool IsOperationMethod(MethodDeclarationSyntax methodDeclaration)
        {
            // Has HTTP verb as decorator in opertation
            return methodDeclaration.AttributeLists.SelectMany(attrList => attrList.Attributes)
                .Any(attribute => attribute.Name.ToString().Contains("Http"));
        }

        private static bool HasTryCatchBlock(MethodDeclarationSyntax methodDeclaration)
        {
            // Does the operation have try catch block?
            var catchClauses = methodDeclaration.DescendantNodes().OfType<CatchClauseSyntax>();
            return catchClauses.Any();
        }
        #endregion Helper Methods
    }
}
