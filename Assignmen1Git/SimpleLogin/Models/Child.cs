using System.Collections.Generic;

namespace SimpleLogin.Models {
    public class Child : Person {
    
        public List<Interest> Interests { get; set; }
        public List<Pet> Pets { get; set; }

        public Child()
        {
            Interests = new List<Interest>();
            Pets = new List<Pet>();
        }

    }
}