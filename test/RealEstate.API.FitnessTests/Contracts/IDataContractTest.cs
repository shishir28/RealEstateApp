namespace RealEstate.API.FitnessTests.Contracts; 

internal interface IDataContractTest
{
    bool DoContractsMatch(HttpResponseMessage expectedResponse, HttpResponseMessage actualResponse);
    bool DoContractsMatch(string expectedResponse, HttpResponseMessage actualResponse);
    bool DoContractsMatch(string expectedResponse, string actualResponse);
}
