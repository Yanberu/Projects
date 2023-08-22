namespace Project_20.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string Mail { get; set; }
        public string Telephone { get; set; }
        public string Adress { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"ФИО: {LastName} {FirstName} {FatherName}\n" +
                  $"тел.: {Telephone}\n" +
                  $"e-mail: {Mail}\n" +
                  $"адрес: {Adress}\n" +
                  $"описание: {Description}\n";
        }
    }
}
