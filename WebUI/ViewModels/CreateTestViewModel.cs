using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebUI.ViewModels
{
    public class CreateTestViewModel
    {
        [StringLength(50)]
        public string Name { get; set; }    
        [Range(1, 60)]
        public int Time { get; set; }    
        [StringLength(200)]
        public string Discription { get; set; }
        public string Creator { get; set; }
        public List<string> Answers { get; set; }
        public List<string> Questions { get; set; }
    }
}