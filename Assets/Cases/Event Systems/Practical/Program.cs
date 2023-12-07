using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PracticalExample {
    public class Program : MonoBehaviour {
        private void Start() {
            var guild = new Guild();
            var welcomer = new MemberWelcomer();
            var hall = new GuildHall();

            guild.AddMember("Nope");
        }
    }
}