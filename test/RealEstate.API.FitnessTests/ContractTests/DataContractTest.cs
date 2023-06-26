using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace RealEstate.API.FitnessTests.ContractTests;

public interface IDataContractValidator
{

    bool DoContractsMatchForArray(JSchema expectedSchema, string actualResponse);
    bool DoContractsMatch(JSchema expectedSchema, string actualResponse);

}
/// <summary>
///  We can break down this class into multiple classes if it becomes very big
/// </summary>
public class DataContractValidator : IDataContractValidator
{

    public bool DoContractsMatch(JSchema expectedSchema, string actualResponseString)
    {
        var parsedObject = JObject.Parse(actualResponseString);
        var result = parsedObject.IsValid(expectedSchema, out IList<string> _);
        return result;
    }

    public bool DoContractsMatchForArray(JSchema expectedSchema, string actualResponseString)
    {
        var parsedObject = JArray.Parse(actualResponseString);
        var result = parsedObject.IsValid(expectedSchema, out IList<string> _);
        return result;
    }
}
