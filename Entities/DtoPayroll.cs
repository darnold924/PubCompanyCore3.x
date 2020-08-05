﻿namespace Entities
{
    public class DtoPayroll
    {
        public int PayRollId { get; set; }
        public int AuthorId { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public int? Salary { get; set; }
    }
}
