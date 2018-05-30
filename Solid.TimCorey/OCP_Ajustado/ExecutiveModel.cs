namespace OCP_Ajustado
{
    public class ExecutiveModel : IApplicantModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IAccounts AccountCreator { get; set; } = new ExecutiveAccount();
    }




}
