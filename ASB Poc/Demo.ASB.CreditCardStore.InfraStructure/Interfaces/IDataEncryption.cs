
namespace Demo.ASB.CreditCardStore.InfraStructure.Interfaces
{
    public interface IDataEncryption
    {
        string EncryptData(string data);
        string DecryptData(string data);
    }
}