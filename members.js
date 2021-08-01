export const Members = {
  members: [],
  initMember: (name, bossMember) => ({
    name: name,
    boss: bossMember || null
  }),
  getSubordinates: (member) => Members.members.filter((v) => v.boss === member),
  unemploy: (member) => {
    //запомнить босса этого сотрудника
    let bossMember = member.boss;
    //перевести его подчиненных в подчинение к его боссу
    let exSubordinates = Members.getSubordinates(member);
    //удалить из массива этого сотрудника
    let index = Members.members.indexOf(member);
    Members.members = Members.members.filter((v, i) => i !== index);
    exSubordinates.forEach((m) => {
      m.boss = bossMember;
    });
    for (let listener of Members.unemployListeners) {
      if (!!listener) listener();
    }
  },
  unemployListeners: []
};

//sample data
Members.members.push(Members.initMember("john"));
Members.members.push(Members.initMember("jack", Members.members[0]));
Members.members.push(Members.initMember("mike", Members.members[1]));
Members.members.push(Members.initMember("bob", Members.members[1]));
Members.members.push(Members.initMember("rick", Members.members[2]));
