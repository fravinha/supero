namespace teste_supero.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class task_list
    {
        public int ID { get; set; }
        public string titulo { get; set; }
        public string descricao { get; set; }
        public Nullable<bool> concluido { get; set; }
        public Nullable<System.DateTime> dataInclusao { get; set; }
        public Nullable<System.DateTime> dataAlteracao { get; set; }
    }
}
