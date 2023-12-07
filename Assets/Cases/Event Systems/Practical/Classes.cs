using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PracticalExample {
    public class Guild {
        private readonly List<string> _members = new List<string>();

        public static event Action<string> NewMemberAdded;

        public void AddMember(string memberName) {
            _members.Add(memberName);

            NewMemberAdded?.Invoke(memberName);
        }
    }

    public class MemberWelcomer {
        public MemberWelcomer()
        {
            Guild.NewMemberAdded += WelcomeMember;
        }

        public void WelcomeMember(string memberName) {
            Debug.Log($"Welcome {memberName}");
        }
    }

    public class GuildHall {
        public GuildHall()
        {
            Guild.NewMemberAdded += BedRoom;
        }

        public void BedRoom(string memberName) {
            Debug.Log($"A room was added to the guild hall for {memberName}");
        }
    }
}
