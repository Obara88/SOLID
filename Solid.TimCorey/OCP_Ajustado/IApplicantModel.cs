namespace OCP_Ajustado
{
    public interface IApplicantModel
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        IAccounts AccountCreator { get; set; }
    }
}
