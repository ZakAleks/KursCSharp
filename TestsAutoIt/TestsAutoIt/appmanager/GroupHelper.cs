using System;
using System.Collections.Generic;

namespace TestsAutoIt
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) : base(manager) { }

        public static string GROUPWINTITLE = "Group editor";

        public static string GROUPDELWINTITLE = "Delete group";

        public List<GroupData> GetGroupList()
        {
            List<GroupData> groups = new List<GroupData>();
            OpenGroupsDialogue();
            string count = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetItemCount", "#0", "");
            for (int i = 0; i < int.Parse(count); i++)
            {
                string textGroupName = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetText", "#0|#"+i, "");
                groups.Add(new GroupData() { Name = textGroupName });
            }
            CloseGroupsDialogue();
            return groups;
        }

        internal int GetGroupsCounts()
        {
            OpenGroupsDialogue();
            var count = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetItemCount", "#0", "");
            CloseGroupsDialogue();
            return int.Parse(count);
        }

        internal void Delete(int index)
        {
            // открываем груп эдит
            OpenGroupsDialogue();
            //нажимаем на нужный элемент в дереве
            aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "Select", "#0|#" + index, "");
            // нажимаем кнопку удалить
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");
            aux.WinWait(GROUPDELWINTITLE);
            // нажимаем на кнопку ок
            aux.ControlClick(GROUPDELWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            aux.WinWait(GROUPWINTITLE);
            // закрываем окно 
            CloseGroupsDialogue();
        }

        public void AddGroup(GroupData newGroup)
        {
            OpenGroupsDialogue();
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            aux.Send(newGroup.Name);
            aux.Send("{ENTER}");
            CloseGroupsDialogue();
        }

        private void CloseGroupsDialogue()
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d54");
            aux.WinWait(WINTITLE);
        }

        private void OpenGroupsDialogue()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512");
            aux.WinWait(GROUPWINTITLE);
        }
    }
}