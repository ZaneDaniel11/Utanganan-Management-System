using System;
using System.Collections.Generic;

namespace PrelimCoop.Entities;

public partial class ClientsInfoTb
{
    public int Id { get; set; }

    public string UserType { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int ZipCode { get; set; }

    public string Birthday { get; set; } = null!;

    public int Age { get; set; }

    public string NameOfFather { get; set; } = null!;

    public string NameOfMother { get; set; } = null!;

    public string CivilStatus { get; set; } = null!;

    public string Religion { get; set; } = null!;

    public string Occupation { get; set; } = null!;

    public virtual Usertype? Usertype { get; set; }
}
