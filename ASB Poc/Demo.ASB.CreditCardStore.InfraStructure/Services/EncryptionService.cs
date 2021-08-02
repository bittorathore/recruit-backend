
using Demo.ASB.CreditCardStore.InfraStructure.Interfaces;
using Microsoft.AspNetCore.DataProtection;

namespace Demo.ASB.CreditCardStore.InfraStructure.Services
{
    public class EncryptionService : IDataEncryption
    {
        private readonly IDataProtector _dataProtector;
        public EncryptionService(IDataProtectionProvider dataProtector)
        {
            _dataProtector = dataProtector.CreateProtector("Infrastructure.EncryptionService");
        }

        public string DecryptData(string data)
        {
           return _dataProtector.Unprotect(data);
        }

        public string EncryptData(string data)
        {
            return _dataProtector.Protect(data);
        }
    }
}
