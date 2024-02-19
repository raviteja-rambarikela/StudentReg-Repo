namespace StudentRegistrationForm.DAL
{
    internal class sqlConnection
    {
        public sqlConnection(string dbConn)
        {
            DbConn = dbConn;
        }

        public string DbConn { get; }
    }
}