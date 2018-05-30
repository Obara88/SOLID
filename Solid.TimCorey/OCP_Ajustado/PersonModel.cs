namespace OCP_Ajustado
{
    public class PersonModel : IApplicantModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IAccounts AccountCreator { get; set; } = new Accounts();
    }
}
