using System.Collections.Generic;

namespace Core.DTOs
{
    public class CategoryDTO
    {
        public CategoryDTO()
        {
            Groups = new List<GroupDTO>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public List<GroupDTO> Groups { get; set; }
    }
}
