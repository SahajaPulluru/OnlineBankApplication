namespace UserService.Utilities
{
    public class AccountNumberHelper
    {
        private Random random;

        public string GenerateAccountUniqueId(char acctypeid)
        {
            if (this.random == null)
            {
                this.random = new Random();
            }

            char[] generated = new char[11];

            generated[0] = Char.Parse("W");
            generated[1] = Char.Parse("F");
            generated[2] = Char.Parse("C");
            generated[3] = acctypeid;
            for (int i = 0; i < 7; i++)
            {
                generated[i + 4] = (char)('0' + this.random.Next(10));
            }

          

            return string.Join("", generated);
        }
    }
}
