
using Core.Entities;
using System.Collections.Generic;

namespace Core.DTOs
{
    public class GroupDTO
    {
        public GroupDTO()
        {
            MenuItems = new List<MenuItemDTO>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MenuItemDTO> MenuItems { get; set; }
    }
}
