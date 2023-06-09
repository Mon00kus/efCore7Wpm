using System;
using System.Collections.Generic;

namespace ejemploScaffolding;

public partial class Species
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Pet> Pets { get; set; } = new List<Pet>();
}
