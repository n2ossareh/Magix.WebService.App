using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;



namespace Magix.WebService.Models;

[Supabase.Postgrest.Attributes.Table("Leader")]
public class Leader : BaseModel
{
        [PrimaryKey("id", false)]
        public Guid Id { get; set; }
        [Supabase.Postgrest.Attributes.Column("email")]
        public string Email { get; set; }

        [Supabase.Postgrest.Attributes.Column("display_name")]
        public string DisplayName { get; set; }

        [Supabase.Postgrest.Attributes.Column("user_role")]
        public string Role { get; set; }

}

