using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainProject;
using MainProject.Model;

namespace MainProject
{
    enum Permision
    {
        school,
        Depart,
        professor,
        student
    }

    class MainClass
    {
        //학과명
        const string computerClass = "컴퓨터공학과";
        const string CallClass = "정보통신과";
      
        const string root = "root";
        const string Professor = "Professor";
        const string Student = "Student";
        List<DepartmentInfo> deparmentList = new List<DepartmentInfo>();
        List<Person> PersonList = new List<Person>();
        List<Subject> subjectList =null;
        List<SubjectEnd> subjectEndList =null;
        Login login = null;

        public MainClass()
        {
            init();

            while (true)
            {
                Console.Write("ID 입력하세요 : ");
                string id = Console.ReadLine();
                if (id == "exit") break;
                Console.Write("PW 입력하세요 : ");
                string pw = Console.ReadLine();

                int conid = int.Parse(id);
                if (Login(conid, pw))
                {
                    if (login.per == Permision.school)
                    {
                        //학교어드민
                        school_admin();
                    }
                    else if (login.per == Permision.Depart)
                    {
                        //학과어드민
                        depart_admin();
                    }
                    else if (login.per == Permision.professor)
                    {
                        //교수로그인
                        professor_login();
                    }
                    else
                    {
                        //학생로그인
                        student_login();
                    }
                }
                else
                {
                    Console.WriteLine("아이디 및 패스워드 틀렸습니다 다시 입력하세요 ");
                }
                Console.WriteLine("종료를 원하시면 ID에 exit를 입력해주세요.");
            }
        }

        //초기화
        private void init()
        {
            PersonList.Add(new root(1001, 0, string.Empty, "학교 관리자", "관리부", "admin", true));
            PersonList.Add(new root(1002, 0, string.Empty, "학급 관리자", "관리부", "admin2", false));

            //수강 이름
            const string Class1 = "학률과통계";
            const string Class2 = "정보보호개론";
            const string Class3 = "운영체제";
            const string Class4 = ".NET프로그래밍";
            const string Class5 = "파이썬프로그래밍";
            const string Class6 = "자료구조";
            const string Class7 = "컴퓨터네트워크";
            const string Class8 = "고급프로그래밍";
            const string Class9 = "이산구조";
            const string Class10 = "공학소프트웨어";
            const string Class11 = "공학소프트웨어";
            const string Class12 = "시스템프로그래밍";
            const string Class13 = "데이터구조";
            const string Class14= "DB프로그래밍";
            const string Class15= "자바프로그래밍";
            const string Class16= "웹프로그래밍";
            const string Class17= "임베디드OS";
            const string Class18= "모바일프로그래밍";
            const string Class19= "정보통신기초";
            const string Class20= "정보통신보안";
          
            PersonList.Add(new Professor(1111, 01011111111, "1111@hnu.kr", "이강수", computerClass, "1111", 10000000, Class1, "교수", "22년01월01일"));
            PersonList.Add(new Professor(1112, 01011112222, "1112@hnu.kr", "이  극", computerClass, "1112", 10000000, Class2, "교수", "22년01월02일"));
            PersonList.Add(new Professor(1113, 01011113333, "1113@hnu.kr", "최의인", computerClass, "1113", 10000000, Class3, "교수", "22년01월03일"));
            PersonList.Add(new Professor(1114, 01011114444, "1114@hnu.kr", "이만희", computerClass, "1114", 10000000, Class4, "교수", "22년01월04일"));
            PersonList.Add(new Professor(1115, 01011115555, "1115@hnu.kr", "안기영", computerClass, "1115", 10000000, Class5, "조교수", "22년01월05일"));
            PersonList.Add(new Professor(1116, 01011116666, "1116@hnu.kr", "장준혁", computerClass, "1116", 10000000, Class6, "조교수", "22년01월06일"));
            PersonList.Add(new Professor(1117, 01011117777, "1117@hnu.kr", "장효경", computerClass, "1117", 10000000, Class7, "조교수", "22년01월07일"));
            PersonList.Add(new Professor(1118, 01011118888, "1118@hnu.kr", "이상구", computerClass, "1118", 10000000, Class8, "명예교수", "22년01월08일"));
            PersonList.Add(new Professor(1119, 01011119999, "1119@hnu.kr", "이재광", computerClass, "1119", 10000000, Class9, "명예교수", "22년01월09일"));
            PersonList.Add(new Professor(1120, 01022221111, "1120@hnu.kr", "소우영", computerClass, "1120", 10000000, Class10, "정교수", "22년01월10일"));
                                                                   
            PersonList.Add(new Professor(1121, 01022222222, "1121@hnu.kr", "윤영선",  CallClass, "1121", 10000000, Class11, "교수", "22년02월01일"));
            PersonList.Add(new Professor(1122, 01022223333, "1122@hnu.kr", "박성우",  CallClass, "1122", 10000000, Class12, "교수", "22년02월02일"));
            PersonList.Add(new Professor(1123, 01022224444, "1123@hnu.kr", "은성배",  CallClass, "1123", 10000000, Class13, "교수", "22년02월03일"));
            PersonList.Add(new Professor(1124, 01022225555, "1124@hnu.kr", "류성한",  CallClass, "1124", 10000000, Class14, "교수", "22년02월04일"));
            PersonList.Add(new Professor(1125, 01022226666, "1125@hnu.kr", "차  신",  CallClass, "1125", 10000000, Class15, "부교수", "22년02월05일"));
            PersonList.Add(new Professor(1126, 01022227777, "1126@hnu.kr", "유동호",  CallClass, "1126", 10000000, Class16, "조교수", "22년02월06일"));
            PersonList.Add(new Professor(1127, 01022228888, "1127@hnu.kr", "정광현",  CallClass, "1127", 10000000, Class17, "조교수", "22년02월07일"));
            PersonList.Add(new Professor(1128, 01022229999, "1128@hnu.kr", "김경태",  CallClass, "1128", 10000000, Class18, "명예교수", "22년02월08일"));
            PersonList.Add(new Professor(1129, 01033331111, "1129@hnu.kr", "박대철",  CallClass, "1129", 10000000, Class19, "명예교수", "22년02월09일"));
            PersonList.Add(new Professor(1130, 01033332222, "1130@hnu.kr", "백제인", CallClass, "1130", 10000000, Class20, "명예교수", "22년02월10일"));
            

            PersonList.Add(new Staff(2222, 01012341111, "2222@hnu.kr", "조교1", computerClass, "2222", 2000000, Class4,"조교", "22년03월01일"));
            PersonList.Add(new Staff(2223, 01012342222, "2223@hnu.kr", "조교2", computerClass, "2223", 2000000, Class3, "조교", "22년03월02일"));
            PersonList.Add(new Staff(2224, 01012343333, "2224@hnu.kr", "조교3", CallClass, "2224", 1000000, Class13, "조교", "22년03월03일"));
            PersonList.Add(new Staff(2225, 01012344444, "2225@hnu.kr", "조교4", CallClass, "2225", 1500000, Class20, "조교", "22년03월04일"));


            PersonList.Add(new Student(100, 01043211111, "100@hnu.kr", "학생0", computerClass, "100", "성적우수장학", 2.0));
            PersonList.Add(new Student(101, 01043211112, "101@hnu.kr", "학생1", computerClass, "101", "다자녀장학", 2.5));
            PersonList.Add(new Student(102, 01043211113, "102@hnu.kr", "학생2", computerClass, "102", "국가장학", 3.0));
            PersonList.Add(new Student(103, 01043211114, "103@hnu.kr", "학생3", computerClass, "103", "성적우수장학", 4.3));
            PersonList.Add(new Student(104, 01043211115, "104@hnu.kr", "학생4", computerClass, "104", "어학성적우수장학", 3.4));
            PersonList.Add(new Student(105, 01043211116, "105@hnu.kr", "학생5", computerClass, "105", "국가장학", 3.0));
            PersonList.Add(new Student(106, 01043211117, "106@hnu.kr", "학생6", computerClass, "106", "다자녀장학", 3.5));
            PersonList.Add(new Student(107, 01043211118, "107@hnu.kr", "학생7", computerClass, "107", "성적우수장학", 4.0));
            PersonList.Add(new Student(108, 01043211119, "108@hnu.kr", "학생8", computerClass, "108", "어학성적우수장학", 4.5));
            PersonList.Add(new Student(109, 01043211120, "109@hnu.kr", "학생9", computerClass, "109", "장학내역없음", 4.1));
                                                                
            PersonList.Add(new Student(200, 01043221111, "200@hnu.kr", "학생10", CallClass, "200", "성적우수장학", 2.0));
            PersonList.Add(new Student(201, 01043221112, "201@hnu.kr", "학생11", CallClass, "201", "다자녀장학", 2.5));
            PersonList.Add(new Student(202, 01043221113, "202@hnu.kr", "학생12", CallClass, "202", "국가장학", 3.0));
            PersonList.Add(new Student(203, 01043221114, "203@hnu.kr", "학생13", CallClass, "203", "성적우수장학", 4.3));
            PersonList.Add(new Student(204, 01043221115, "204@hnu.kr", "학생14", CallClass, "204", "어학성적우수장학", 3.4));
            PersonList.Add(new Student(205, 01043221116, "205@hnu.kr", "학생15", CallClass, "205", "국가장학", 3.0));
            PersonList.Add(new Student(206, 01043221117, "206@hnu.kr", "학생16", CallClass, "206", "다자녀장학", 3.5));
            PersonList.Add(new Student(207, 01043221118, "207@hnu.kr", "학생17", CallClass, "207", "성적우수장학", 4.0));
            PersonList.Add(new Student(208, 01043221119, "208@hnu.kr", "학생18", CallClass, "208", "어학성적우수장학", 4.5));
            PersonList.Add(new Student(209, 01043221120, "209@hnu.kr", "학생19", CallClass, "209", "장학내역없음", 4.1));
            PersonList.Add(new Student(210, 01043221121, "210@hnu.kr", "학생20", CallClass, "210", "장학내역없음", 4.5));

            List<Professor> tmp_Professor = new List<Professor>();
            List<Student> tmp_Student = new List<Student>();
            List<Professor> tmp_Professor1 = new List<Professor>();
            List<Student> tmp_Student1 = new List<Student>();
            for (int i = 0; i < PersonList.Count; i++)
            {
                switch ((PersonList[i].GetType().Name))
                {
                    

                    case Professor:
                        if ((PersonList[i] as Professor).divison == computerClass)
                        {
                            tmp_Professor.Add(PersonList[i] as Professor);
                        }
                        else if ((PersonList[i] as Professor).divison == CallClass)
                        {
                            tmp_Professor1.Add(PersonList[i] as Professor);
                        }
                        break;

                    case Student:
                           if ((PersonList[i] as Student).divison == computerClass)
                        {
                            tmp_Student.Add(PersonList[i] as Student);
                        }
                        else if ((PersonList[i] as Student).divison == CallClass)
                        {
                            tmp_Student1.Add(PersonList[i] as Student);
                        }
                        break;
                }
            }

            deparmentList.Add(new DepartmentInfo(computerClass, "대전광역시", 0421111111, "조교1", "이만", "computer@h.kr", "www.hn.cm.kr", tmp_Professor, tmp_Student));
            deparmentList.Add(new DepartmentInfo(CallClass, "대전광역시", 042222222, "조교2", "윤영", "datacom@h.kr", "www.hn.dm.kr", tmp_Professor1, tmp_Student1));

          
            subjectList = new List<Subject>();
            subjectEndList = new List<SubjectEnd>();
     
            List<Student> tempStudentList1 = new List<Student>();
            List<Student> tempStudentList2 = new List<Student>();
            List<Student> tempStudentList3 = new List<Student>();
            List<Student> tempStudentList4 = new List<Student>();
            List<Student> tempStudentList5 = new List<Student>();
            List<Student> tempStudentList6 = new List<Student>();
            List<Student> tempStudentList7 = new List<Student>();
            
            for (int cnt = 0; cnt <=2; cnt++)
            {
                Student SubStudent = PersonList.Find(x => x.name == $"학생{cnt}" && x.GetType().Name == Student) as Student;
                tempStudentList1.Add(SubStudent);
            }
            
            for (int cnt =3; cnt <=5; cnt++)
            {
                Student SubStudent2 = PersonList.Find(x => x.name == $"학생{cnt}" && x.GetType().Name == Student) as Student;
                tempStudentList2.Add(SubStudent2);
            }

            
            for (int cnt = 6; cnt <= 8; cnt++)
            {
                Student SubStudent3 = PersonList.Find(x => x.name == $"학생{cnt}" && x.GetType().Name == Student) as Student;
                tempStudentList3.Add(SubStudent3);
            }
            
            for (int cnt = 9; cnt <= 11; cnt++)
            {
                Student SubStudent7 = PersonList.Find(x => x.name == $"학생{cnt}" && x.GetType().Name == Student) as Student;
                tempStudentList7.Add(SubStudent7);
            }
            
            for (int cnt = 12; cnt <= 14; cnt++)
            {
                Student SubStudent4 = PersonList.Find(x => x.name == $"학생{cnt}" && x.GetType().Name == Student) as Student;
                tempStudentList4.Add(SubStudent4);
            }
            
            for (int cnt = 15; cnt <= 17; cnt++)
            {
                Student SubStudent5 = PersonList.Find(x => x.name == $"학생{cnt}" && x.GetType().Name == Student) as Student;
                tempStudentList5.Add(SubStudent5);
            }
            
            for (int cnt = 18; cnt <= 20; cnt++)
            {
                Student SubStudent6 = PersonList.Find(x => x.name == $"학생{cnt}" && x.GetType().Name == Student) as Student;
                tempStudentList6.Add(SubStudent6);
            }
            Professor Subprofessor1 = PersonList.Find(x => x.GetType().Name == Professor && ((Professor)x).teachSub == Class1) as Professor;
            Professor Subprofessor2 = PersonList.Find(x => x.GetType().Name == Professor && ((Professor)x).teachSub == Class2) as Professor;
            Professor Subprofessor3 = PersonList.Find(x => x.GetType().Name == Professor && ((Professor)x).teachSub == Class3) as Professor;
            Professor Subprofessor4 = PersonList.Find(x => x.GetType().Name == Professor && ((Professor)x).teachSub == Class4) as Professor;
            Professor Subprofessor5 = PersonList.Find(x => x.GetType().Name == Professor && ((Professor)x).teachSub == Class5) as Professor;
            Professor Subprofessor6 = PersonList.Find(x => x.GetType().Name == Professor && ((Professor)x).teachSub == Class6) as Professor;
            Professor Subprofessor7 = PersonList.Find(x => x.GetType().Name == Professor && ((Professor)x).teachSub == Class7) as Professor;
            Professor Subprofessor8 = PersonList.Find(x => x.GetType().Name == Professor && ((Professor)x).teachSub == Class8) as Professor;
            Professor Subprofessor9 = PersonList.Find(x => x.GetType().Name == Professor && ((Professor)x).teachSub == Class9) as Professor;
            Professor Subprofessor10 = PersonList.Find(x => x.GetType().Name == Professor && ((Professor)x).teachSub == Class10) as Professor;
            Professor Subprofessor11 = PersonList.Find(x => x.GetType().Name == Professor && ((Professor)x).teachSub == Class11) as Professor;
            Professor Subprofessor12 = PersonList.Find(x => x.GetType().Name == Professor && ((Professor)x).teachSub == Class12) as Professor;
            Professor Subprofessor13 = PersonList.Find(x => x.GetType().Name == Professor && ((Professor)x).teachSub == Class13) as Professor;
            Professor Subprofessor14 = PersonList.Find(x => x.GetType().Name == Professor && ((Professor)x).teachSub == Class14) as Professor;
            Professor Subprofessor15 = PersonList.Find(x => x.GetType().Name == Professor && ((Professor)x).teachSub == Class15) as Professor;
            Professor Subprofessor16 = PersonList.Find(x => x.GetType().Name == Professor && ((Professor)x).teachSub == Class16) as Professor;
            Professor Subprofessor17 = PersonList.Find(x => x.GetType().Name == Professor && ((Professor)x).teachSub == Class17) as Professor;
            Professor Subprofessor18 = PersonList.Find(x => x.GetType().Name == Professor && ((Professor)x).teachSub == Class18) as Professor;
            Professor Subprofessor19 = PersonList.Find(x => x.GetType().Name == Professor && ((Professor)x).teachSub == Class19) as Professor;
            Professor Subprofessor20 = PersonList.Find(x => x.GetType().Name == Professor && ((Professor)x).teachSub == Class20) as Professor;


            subjectList.Add(new Subject(1, Class1, Subprofessor1, "90000", tempStudentList1));
            subjectList.Add(new Subject(2, Class2, Subprofessor2, "90001", tempStudentList1));
            subjectList.Add(new Subject(3, Class3, Subprofessor3, "90002", tempStudentList1));
            subjectList.Add(new Subject(4, Class4, Subprofessor4, "90003", tempStudentList2));
            subjectList.Add(new Subject(5, Class5, Subprofessor5, "90004", tempStudentList2));
            subjectList.Add(new Subject(6, Class6, Subprofessor6, "90005", tempStudentList2));
            subjectList.Add(new Subject(7, Class7, Subprofessor7, "90006", tempStudentList3));
            subjectList.Add(new Subject(8, Class8, Subprofessor8, "90007", tempStudentList3));
            subjectList.Add(new Subject(9, Class9, Subprofessor9, "90008", tempStudentList3));
            
            subjectList.Add(new Subject(10, Class10, Subprofessor10, "90009", tempStudentList4));
            subjectList.Add(new Subject(11, Class11, Subprofessor11, "90010", tempStudentList4));
            subjectList.Add(new Subject(12, Class12, Subprofessor12, "90011", tempStudentList4));
            subjectList.Add(new Subject(13, Class13, Subprofessor13, "90012", tempStudentList5));
            subjectList.Add(new Subject(14, Class14, Subprofessor14, "90013", tempStudentList5));
            subjectList.Add(new Subject(15, Class15, Subprofessor15, "90014", tempStudentList5));
            subjectList.Add(new Subject(16, Class16, Subprofessor16, "90015", tempStudentList6));
            subjectList.Add(new Subject(17, Class17, Subprofessor17, "90016", tempStudentList6));
            subjectList.Add(new Subject(18, Class18, Subprofessor18, "90017", tempStudentList6));
            subjectList.Add(new Subject(19, Class19, Subprofessor19, "90018", tempStudentList7));
            subjectList.Add(new Subject(20, Class20, Subprofessor20, "90019", tempStudentList7));

            
            subjectEndList.Add(new SubjectEnd(1, Class1, Subprofessor1,"90000", new List<Student>()));
            subjectEndList.Add(new SubjectEnd(2, Class2, Subprofessor2,"90001", new List<Student>()));
            subjectEndList.Add(new SubjectEnd(3, Class3, Subprofessor3,"90002", new List<Student>()));
            subjectEndList.Add(new SubjectEnd(4, Class4, Subprofessor4,"90003", new List<Student>()));
            subjectEndList.Add(new SubjectEnd(5, Class5, Subprofessor5,"90004", new List<Student>()));
            subjectEndList.Add(new SubjectEnd(6, Class6, Subprofessor6,"90005", new List<Student>()));
            subjectEndList.Add(new SubjectEnd(7, Class7, Subprofessor7,"90006", new List<Student>()));
            subjectEndList.Add(new SubjectEnd(8, Class8, Subprofessor8,"90007", new List<Student>()));
            subjectEndList.Add(new SubjectEnd(9, Class9, Subprofessor9,"90008", new List<Student>()));
           
            subjectEndList.Add(new SubjectEnd(10, Class10, Subprofessor10, "90009", new List<Student>()));
            subjectEndList.Add(new SubjectEnd(11, Class11, Subprofessor11, "90010", new List<Student>()));
            subjectEndList.Add(new SubjectEnd(12, Class12, Subprofessor12, "90011", new List<Student>()));
            subjectEndList.Add(new SubjectEnd(13, Class13, Subprofessor13, "90012", new List<Student>()));
            subjectEndList.Add(new SubjectEnd(14, Class14, Subprofessor14, "90013", new List<Student>()));
            subjectEndList.Add(new SubjectEnd(15, Class15, Subprofessor15, "90014", new List<Student>()));
            subjectEndList.Add(new SubjectEnd(16, Class16, Subprofessor16, "90015", new List<Student>()));
            subjectEndList.Add(new SubjectEnd(17, Class17, Subprofessor17, "90016", new List<Student>()));
            subjectEndList.Add(new SubjectEnd(18, Class18, Subprofessor18, "90017", new List<Student>()));
            subjectEndList.Add(new SubjectEnd(19, Class19, Subprofessor19, "90018", new List<Student>()));
            subjectEndList.Add(new SubjectEnd(20, Class20, Subprofessor20, "90019", new List<Student>()));
        }

        private bool Login(int id, string pw)
        {
            Person temp = PersonList.Find(x => x.ID == id && x.PW == pw);
            if (temp == null)
                return false;
            else
            {
                switch (temp.GetType().Name)
                {
                    case root:
                        root admin = temp as root;
                        if (admin.isSuper)
                            login = new Login(id, pw, Permision.school);
                        else
                            login = new Login(id, pw, Permision.Depart);
                        break;

                    case Professor:
                        login = new Login(id, pw, Permision.professor);
                        break;

                    case Student:
                        login = new Login(id, pw, Permision.student);
                        break;
                }
            }
            return true;
        }

        private void school_admin()
        {
            List<Professor> affProfessorList = new List<Professor>();
            List<Student> affStudentList = new List<Student>();

            Console.WriteLine("학교 admin 로그인 완료");
            while (true)
            {
                Console.WriteLine("-------메뉴------");
                Console.WriteLine("1.학과관리");
                Console.WriteLine("2.교수관리");
                Console.WriteLine("3.학생관리");
                Console.WriteLine("4.교과목관리");
                Console.WriteLine("5.로그아웃");
                int num = int.Parse(Console.ReadLine());

                switch (num)
                {
                    case 1:
                        DepartmentInfo departmentInfo = new DepartmentInfo();
                        Console.WriteLine("학과관리 메뉴입니다.");
                        Console.WriteLine("1.학과 추가");
                        Console.WriteLine("2.학과 변경");
                        int num1 = int.Parse(Console.ReadLine());
                        if (num1 == 1)
                        {
                            Console.Write("학과명:");
                            departmentInfo.name = Console.ReadLine();
                            Console.Write("주소:");
                            departmentInfo.address = Console.ReadLine();
                            Console.Write("전화번호:");
                            departmentInfo.phone = int.Parse(Console.ReadLine());
                            Console.Write("조교명:");
                            departmentInfo.assistentName = Console.ReadLine();
                            Console.Write("학과장명:");
                            departmentInfo.headName = Console.ReadLine();
                            Console.Write("이메일:");
                            departmentInfo.email = Console.ReadLine();
                            Console.Write("웹사이트:");
                            departmentInfo.webSite = Console.ReadLine();

                            while (true)
                            {
                                Console.Write("추가할 교수 사번을 입력해주세요.");
                                int add_pr = int.Parse(Console.ReadLine());
                                Professor add_prid = (PersonList.Find(x => x.ID == add_pr)) as Professor;
                                if (add_prid == null)
                                {
                                    Console.WriteLine("교수 사번을 잘못입력했습니다.");
                                }
                                else
                                {
                                    affProfessorList.Add(add_prid);
                                }
                                Console.WriteLine("더 추가를 원하시면 아무키를 눌러주세요.");
                                Console.WriteLine("그만 추가하실려면 exit를 입력해주세요.");
                                string exit = Console.ReadLine();
                                if (exit == "exit") break;
                            }

                            while (true)
                            {
                                Console.Write("추가할 학생 학번을 입력해주세요.");
                                int add_st = int.Parse(Console.ReadLine());
                                Student add_stid = (PersonList.Find(x => x.ID == add_st)) as Student;
                                if (add_stid == null)
                                {
                                    Console.WriteLine("학생 학번을 잘못입력했습니다.");
                                }
                                else
                                {
                                    affStudentList.Add(add_stid);
                                }
                                Console.WriteLine("더 추가를 원하시면 아무키를 눌러주세요.");
                                Console.WriteLine("그만 추가하실려면 exit를 입력해주세요.");
                                string exit = Console.ReadLine();
                                if (exit == "exit") break;
                            }
                            deparmentList.Add(new DepartmentInfo(departmentInfo.name, departmentInfo.address, departmentInfo.phone, departmentInfo.assistentName, departmentInfo.headName, departmentInfo.email, departmentInfo.webSite, affProfessorList, affStudentList));
                        }
                        else if (num1 == 2)
                        {
                            Console.Write("변경할 학과: ");
                            string ch_name = Console.ReadLine();
                            DepartmentInfo ch_department = deparmentList.Find(x => x.name == ch_name);
                            if (ch_department == null)
                            {
                                Console.WriteLine("학과를 잘못 입력했습니다.");
                            }
                            else
                            {
                                DepartmentInfo change_department = new DepartmentInfo();
                                Console.Write("학과명:");
                                change_department.name = Console.ReadLine();
                                Console.Write("주소:");
                                change_department.address = Console.ReadLine();
                                Console.Write("전화번호:");
                                change_department.phone = int.Parse(Console.ReadLine());
                                Console.Write("조교명:");
                                change_department.assistentName = Console.ReadLine();
                                Console.Write("학과장명:");
                                change_department.headName = Console.ReadLine();
                                Console.Write("이메일:");
                                change_department.email = Console.ReadLine();
                                Console.Write("웹사이트:");
                                change_department.webSite = Console.ReadLine();
                                ch_department.modify(change_department);
                            }
                        }
                        break;
                    case 2:
                        Professor professors = new Professor();
                        Console.WriteLine("교수관리 메뉴입니다.");
                        Console.WriteLine("1.교수 추가");
                        Console.WriteLine("2.교수 변경");
                        Console.WriteLine("3.교수 삭제");
                        int num2 = int.Parse(Console.ReadLine());
                        if (num2 == 1)
                        {
                            Console.Write("사번:");
                            professors.ID = int.Parse(Console.ReadLine());
                            Console.Write("전화번호:");
                            professors.phoneNum = int.Parse(Console.ReadLine());
                            Console.Write("이메일:");
                            professors.email = Console.ReadLine();
                            Console.Write("이름:");
                            professors.name = Console.ReadLine();
                            Console.Write("학과:");
                            professors.divison = Console.ReadLine();
                            Console.Write("비밀번호:");
                            professors.PW = Console.ReadLine();
                            Console.Write("월급여:");
                            professors.payMent = int.Parse(Console.ReadLine());
                            Console.Write("강의과목:");
                            professors.teachSub = Console.ReadLine();
                            Console.Write("직급:");
                            professors.rank = Console.ReadLine();
                            Console.Write("입사일:");
                            professors.entryDate = Console.ReadLine();
                            PersonList.Add(new Professor(professors.ID, professors.phoneNum, professors.email, professors.name, professors.divison, professors.PW, professors.payMent, professors.teachSub, professors.rank, professors.entryDate));
                        }
                        else if (num2 == 2)
                        {

                            Console.Write("변경할 교수 사번:");
                            int ch_id = int.Parse(Console.ReadLine());
                            Professor ch_professor = (PersonList.Find(x => x.ID == ch_id)) as Professor;
                            if (ch_professor != null)
                            {
                                Professor change_professor = new Professor();
                                Console.Write("전화번호:");
                                change_professor.phoneNum = int.Parse(Console.ReadLine());
                                Console.Write("이메일:");
                                change_professor.email = Console.ReadLine();
                                Console.Write("학과:");
                                change_professor.divison = Console.ReadLine();
                                Console.Write("월급여:");
                                change_professor.payMent = int.Parse(Console.ReadLine());
                                Console.Write("강의과목:");
                                change_professor.teachSub = Console.ReadLine();
                                Console.Write("직급:");
                                change_professor.rank = Console.ReadLine();
                                ch_professor.modify(change_professor);
                            }
                            else
                            {
                                Console.WriteLine("교수 사번을 잘못입력했습니다.");
                            }
                        }
                        else if (num2 == 3)
                        {
                            Console.Write("삭제할 교수 사번:");
                            int re_id = int.Parse(Console.ReadLine());
                            Professor re_professor = (PersonList.Find(x => x.ID == re_id)) as Professor;
                            if (re_professor != null)
                            {
                                Subject re_subject_pr = subjectList.Find(x => x.allowProfessor == re_professor);

                                for (int i = 0; i < deparmentList.Count; i++)
                                {
                                    int re_de_pr = deparmentList[i].TProfessor.FindIndex(x => x.ID == re_id);
                                    if (re_de_pr == -1) continue;
                                    else
                                    {
                                        deparmentList[i].TProfessor.RemoveAt(re_de_pr); 
                                    }
                                }
                                PersonList.Remove(re_professor);
                            }
                            else
                            {
                                Console.WriteLine("교수 사번을 잘못입력했습니다.");
                            }
                        }
                        break;
                    case 3:
                        Student students = new Student();
                        Console.WriteLine("학생관리 메뉴입니다.");
                        Console.WriteLine("1.학생 추가");
                        Console.WriteLine("2.학생 변경");
                        Console.WriteLine("3.학생 삭제");
                        int num3 = int.Parse(Console.ReadLine());
                        if (num3 == 1)
                        {
                            Console.Write("학번:");
                            students.ID = int.Parse(Console.ReadLine());
                            Console.Write("전화번호:");
                            students.phoneNum = int.Parse(Console.ReadLine());
                            Console.Write("이메일:");
                            students.email = Console.ReadLine();
                            Console.Write("이름:");
                            students.name = Console.ReadLine();
                            Console.Write("소속학과");
                            students.divison = Console.ReadLine();
                            Console.Write("비밀번호:");
                            students.PW = Console.ReadLine();
                            Console.Write("수혜장학금내역:");
                            students.scholarShip = Console.ReadLine();
                            Console.Write("성적:");
                            students.Grade = double.Parse(Console.ReadLine());
                            PersonList.Add(new Student(students.ID, students.phoneNum, students.email, students.name, students.divison, students.PW, students.scholarShip, students.Grade));
                        }
                        else if (num3 == 2)
                        {
                            Console.Write("변경할 학생 학번: ");
                            int ch_id = int.Parse(Console.ReadLine());
                            Person ch_student = PersonList.Find(x => x.ID == ch_id);
                            if (ch_student != null)
                            {
                                Student change_student = new Student();
                                Console.Write("전화번호:");
                                change_student.phoneNum = int.Parse(Console.ReadLine());
                                Console.Write("이메일:");
                                change_student.email = Console.ReadLine();
                                Console.Write("소속학과:");
                                change_student.divison = Console.ReadLine();
                                Console.Write("장학금:");
                                change_student.scholarShip = Console.ReadLine();
                                Console.Write("성적:");
                                change_student.Grade = double.Parse(Console.ReadLine());
                                (change_student as Student).modify(change_student);
                            }
                            else
                            {
                                Console.WriteLine("학생 학번을 잘못입력했습니다.");
                            }

                        }
                        else if (num3 == 3)
                        {
                            Console.Write("삭제할 학생 학번:");
                            int re_id = int.Parse(Console.ReadLine());
                            Person re_student = PersonList.Find(x => x.ID == re_id);
                            if (re_student != null)
                            {
                                PersonList.Remove(re_student);
                                Subject re_st = subjectList.Find(x => x.Cstudent.Find(y => y.ID == re_id) != null);
                                subjectList.Remove(re_st);
                            }
                            else
                            {
                                Console.WriteLine("학생 학번을 잘못입력했습니다.");
                            }
                        }
                        break;
                    case 4:
                        Subject subjects = new Subject();
                        Console.WriteLine("교과목 관리 메뉴입니다.");
                        Console.WriteLine("1.과목 생성");
                        Console.WriteLine("2.과목 삭제");
                        int num4 = int.Parse(Console.ReadLine());
                        if (num4 == 1)
                        {
                            Console.Write("과목코드입력:");
                            subjects.code = int.Parse(Console.ReadLine());
                            var subject = subjectList.Find(x => x.code == subjects.code);
                            if (subject == null)
                            {
                                Console.Write("과목이름:");
                                subjects.Name = Console.ReadLine();
                                subjectList.Add(new Subject(subjects.code, subjects.Name, null, null, null));
                                subjectEndList.Add(new SubjectEnd(subjects.code, subjects.Name, null, null, null));
                            }
                            else
                                Console.Write("과목코드가 중복입니다");
                        }
                        else if (num4 == 2)
                        {
                            Console.Write("삭제할 과목 코드 입력:");
                            int re_su = int.Parse(Console.ReadLine());
                            Subject re_subject = subjectList.Find(x => x.code == re_su);
                            if (re_subject != null)
                            {
                                subjectList.Remove(re_subject);
                                Professor pro =(PersonList.Find(x => x == re_subject.allowProfessor)) as Professor;
                                pro.teachSub = string.Empty;
                            }
                            else
                            {
                                Console.WriteLine("과목 코드를 잘못입력했습니다.");
                            }

                        }
                        break;
                    case 5:
                        Console.WriteLine("로그아웃 되었습니다.");
                        break;
                    default:
                        Console.WriteLine("번호를 잘못입력했어요");
                        school_admin();
                        break;
                }
                if (num == 5) break;
            }
        }
        private void depart_admin()
        {
            Console.WriteLine("학과 admin 로그인 완료");
            while (true)
            {
                Console.WriteLine("-------메뉴------");
                Console.WriteLine("1.학생관리");
                Console.WriteLine("2.교수관리");
                Console.WriteLine("3.수강관리");
                Console.WriteLine("4.로그아웃");
                int num = int.Parse(Console.ReadLine());

                switch (num)
                {
                    case 1:
                        Console.WriteLine("학생관리 메뉴입니다.");
                        Console.WriteLine("학생 변경");
                        Console.Write("변경할 학생 학번:");
                        int ch_id = int.Parse(Console.ReadLine());
                        Person ch_student = PersonList.Find(x => x.ID == ch_id);
                        if (ch_student == null)
                        {
                            Console.WriteLine("해당 학번이 존재하지 않습니다.");
                        }
                        else
                        {
                            Student change_student = new Student();
                            Console.Write("전화번호:");
                            change_student.phoneNum = int.Parse(Console.ReadLine());
                            Console.Write("이메일:");
                            change_student.email = Console.ReadLine();
                            Console.Write("소속학과:");
                            change_student.divison = Console.ReadLine();
                            Console.Write("장학금:");
                            change_student.scholarShip = Console.ReadLine();
                            Console.Write("성적:");
                            change_student.Grade = double.Parse(Console.ReadLine());
                            (ch_student as Student).modify(change_student);
                        }
                        break;
                    case 2:
                        Console.WriteLine("교수관리 메뉴입니다.");
                        Console.WriteLine("교수 변경");
                        Console.Write("변경할 교수 사번:");
                        int ch_id1 = int.Parse(Console.ReadLine());
                        Person ch_professor = PersonList.Find(x => x.ID == ch_id1);
                        if (ch_professor == null)
                        {
                            Console.WriteLine("해당 사번이 존재하지 않습니다.");
                        }
                        else
                        {
                            Professor change_professor = new Professor();
                            Console.Write("전화번호:");
                            change_professor.phoneNum = int.Parse(Console.ReadLine());
                            Console.Write("이메일:");
                            change_professor.email = Console.ReadLine();
                            Console.Write("학과:");
                            change_professor.divison = Console.ReadLine();
                            Console.Write("월급여:");
                            change_professor.payMent = int.Parse(Console.ReadLine());
                            Console.Write("강의과목:");
                            change_professor.teachSub = Console.ReadLine();
                            Console.Write("직급:");
                            change_professor.rank = Console.ReadLine();
                            (ch_professor as Professor).modify(change_professor);
                        }
                        break;
                    case 3:
                        Console.WriteLine("수강관리 메뉴입니다.");
                        Console.WriteLine("1.과목 개설");
                        Console.WriteLine("2.교수 배정");
                        Console.WriteLine("3.강의실 변경");
                        Console.WriteLine("4.학생 수강 등록");
                        Console.WriteLine("5.학생 수강 제거");
                        int num3 = int.Parse(Console.ReadLine());
                        if (num3 == 1)
                        {
                            Subject subjects = new Subject();
                            Console.WriteLine("과목 개설");
                            Console.Write("과목코드입력:");
                            subjects.code = int.Parse(Console.ReadLine());
                            Console.Write("과목이름:");
                            subjects.Name = Console.ReadLine();
                            subjectList.Add(new Subject(subjects.code, subjects.Name, null, null, null));
                        }
                        else if (num3 == 2)
                        {
                            Console.Write("교수 배정할 과목 코드:");
                            int ch_su = int.Parse(Console.ReadLine());
                            int ch_subject = subjectList.FindIndex(x => x.code == ch_su);
                            if (ch_subject != -1)
                            {
                                Console.Write("배정할 교수이름:");
                                string affProfessor = Console.ReadLine();
                                
                                Professor TEMP = PersonList.Find(X => X.name == affProfessor) as Professor;
                                subjectList[ch_subject].allowProfessor = TEMP;
                                var subjectEnd = subjectEndList[ch_subject];
                                subjectEnd.allowProfessor = TEMP;
                            }
                            else
                            {
                                Console.WriteLine("해당 과목은 존재하지 않습니다.");
                            }
                        }
                        else if (num3 == 3)
                        {
                            Console.Write("강의실 변경할 과목 코드:");
                            int ch_le = int.Parse(Console.ReadLine());
                            int ch_subject = subjectList.FindIndex(x => x.code == ch_le);
                            if (ch_subject != -1)
                            {
                                Console.Write("변경할 강의실 입력:");
                                string afflectureRoom = Console.ReadLine();
                                subjectList[ch_subject].lectureRoom = afflectureRoom;
                            }
                            else
                            {
                                Console.WriteLine("해당 과목은 존재하지 않습니다.");
                            }
                        }
                        else if (num3 == 4)
                        {
                            Console.Write("수강 등록할 과목 코드:");
                            int ch_cs = int.Parse(Console.ReadLine());
                            int ch_Cstudent = subjectList.FindIndex(x => x.code == ch_cs);
                            if (ch_Cstudent != -1)
                            {
                                while (true)
                                {
                                    Console.Write("수강 등록할 학생 학번 입력:");
                                    int co_st = int.Parse(Console.ReadLine());
                                    Student co_student = (PersonList.Find(x => x.ID == co_st)) as Student;
                                    if (co_student != null)
                                    {
                                        subjectList[ch_Cstudent].Cstudent.Add(co_student);
                                    }
                                    else
                                    {
                                        Console.WriteLine("다시 입력해주세요.");
                                    }
                                    Console.WriteLine("더 추가를 원하시면 아무키를 눌러주세요.");
                                    Console.WriteLine("그만 추가하실려면 exit를 입력해주세요.");
                                    string exit = Console.ReadLine();
                                    if (exit == "exit") break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("해당 과목은 존재하지 않습니다.");
                            }
                        }
                        else if (num3 == 5)
                        {
                            Console.Write("수강 삭제할 과목 코드:");
                            int re_cs = int.Parse(Console.ReadLine());
                            int re_CStudent = subjectList.FindIndex(x => x.code == re_cs);
                            if (re_CStudent != -1)
                            {
                                while (true)
                                {
                                    Console.Write("수강 삭제할 학생 학번 입력:");
                                    int re_st = int.Parse(Console.ReadLine());
                                    Student re_student = subjectList[re_CStudent].Cstudent.Find(x => x.ID == re_st);
                                    if (re_student == null)
                                    {
                                        Console.WriteLine("다시 입력해주세요.");
                                    }
                                    else
                                    {
                                        subjectList[re_CStudent].Cstudent.Remove(re_student);
                                    }
                                    Console.WriteLine("더 삭제를 원하시면 아무키를 눌러주세요.");
                                    Console.WriteLine("그만 삭제하실려면 exit를 입력해주세요.");
                                    string exit = Console.ReadLine();
                                    if (exit == "exit") break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("해당 과목은 존재하지 않습니다.");
                            }
                        }
                        break;
                    case 4:
                        Console.WriteLine("로그아웃 되었습니다.");
                        break;
                    default:
                        Console.WriteLine("번호를 잘못입력했어요");
                        depart_admin();
                        break;
                }
                if (num == 4) break;
            }
        }
        private void professor_login()
        {
            Console.WriteLine("교수 로그인 완료");
            while (true)
            {
                Console.WriteLine("-------메뉴------");
                Console.WriteLine("1.정보변경");
                Console.WriteLine("2.강의과목관리");
                Console.WriteLine("3.로그아웃");
                int num = int.Parse(Console.ReadLine());

                switch (num)
                {
                    case 1:
                        Console.WriteLine("정보변경 메뉴입니다.");
                        Console.Write("정보변경을 위해 사번을 재입력 해주세요:");
                        int ch_id1 = int.Parse(Console.ReadLine());
                        Professor ch_professor = (PersonList.Find(x => x.ID == ch_id1)) as Professor;
                        if (ch_id1 == login.id)
                        {
                            Professor change_professor = new Professor();
                            Console.Write("전화번호:");
                            change_professor.phoneNum = int.Parse(Console.ReadLine());
                            Console.Write("이메일:");
                            change_professor.email = Console.ReadLine();
                            Console.Write("이름:");
                            change_professor.name = Console.ReadLine();
                            Console.Write("비밀번호:");
                            change_professor.PW = Console.ReadLine();
                            Console.Write("강의과목:");
                            change_professor.teachSub = Console.ReadLine();
                            ch_professor.modify(change_professor);
                        }
                        else
                        {
                            Console.WriteLine("사번을 잘못 입력했습니다.");
                        }

                        break;
                    case 2:
                        Console.WriteLine("강의과목관리 메뉴입니다.");
                        Console.WriteLine("1.강의과목확인");
                        Console.WriteLine("2.수강생정보확인");
                        Console.WriteLine("3.과목별 성적 기입");
                        Console.WriteLine("4.학생별 성적 기입");
                        int num2 = int.Parse(Console.ReadLine());
                        if (num2 == 1)
                        {

                            while (true)
                            {
                                Console.Write("강의 과목 확인을 위해 사번을 재입력 해주세요:");
                                int ck_id = int.Parse(Console.ReadLine());

                                if (ck_id != login.id)
                                {
                                    Console.Write("로그인한 id와 일치하지않아요 다시 입력해주세요.");
                                }
                                else
                                {
                                    Professor ck_professor = (PersonList.Find(x => x.ID == ck_id)) as Professor;
                                    Console.WriteLine("강의 과목:" + ck_professor.teachSub);
                                    break;
                                }
                            }

                        }
                        else if (num2 == 2)
                        {
                            Console.Write("수강생 정보를 확인하고 싶은 과목 코드를 입력해주세요:");
                            int ck_in = int.Parse(Console.ReadLine());
                            Subject ck_student = subjectList.Find(x => x.code == ck_in);
                            if (ck_student != null)
                            {
                                foreach (var item in ck_student.Cstudent)
                                {
                                    Console.WriteLine("수강생 이름:" + item.name);
                                }
                            }
                            else
                            {
                                Console.WriteLine("해당 과목은 존재하지 않습니다.");
                            }
                        }
                        else if (num2 == 3)
                        {
                            Professor ck_professor = (PersonList.Find(x => x.ID == login.id)) as Professor;
                            var imsiStudents = subjectList.Find(x => x.Name == ck_professor.teachSub);
                            foreach (Student imsi in imsiStudents.Cstudent)
                            {
                                Console.Clear();
                                Console.WriteLine("학생 학번 :" + imsi.ID);
                                Console.WriteLine("학생 이름 :" + imsi.name);
                                Console.WriteLine("ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
                                Console.Write("성적입력  =>" );
                                imsi.Grade = double.Parse(Console.ReadLine());
                                imsi.modify(imsi);

                                SubjectEnd sub = subjectEndList.Find(x => x.allowProfessor == ck_professor);
                                sub.Cstudent.Add(imsi);

                                Console.WriteLine("ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");

                            }
                            Console.WriteLine("ㅡㅡㅡㅡ성적입력 완료ㅡㅡㅡㅡㅡㅡ");

                        }
                        else if (num2 == 4)
                        {
                            Professor ck_professor = (PersonList.Find(x => x.ID == login.id)) as Professor;

                            var imsiStudents = subjectList.Find(x => x.Name == ck_professor.teachSub);
                            foreach (Student imsi in imsiStudents.Cstudent)
                            {

                                Console.Clear();

                                Console.WriteLine("학생 학번 :" + imsi.ID);
                                Console.WriteLine("학생 이름 :" + imsi.name);
                                Console.WriteLine("ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
                                Console.Write("성적입력  =>" );
                                imsi.Grade = double.Parse(Console.ReadLine());
                                imsi.modify(imsi);

                                SubjectEnd sub = subjectEndList.Find(x => x.allowProfessor == ck_professor);
                                sub.Cstudent.Add(imsi);

                                Console.WriteLine("ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");

                            }
                            Console.WriteLine("ㅡㅡㅡㅡ성적입력 완료ㅡㅡㅡㅡㅡㅡ");
                        }
                        break;
                    case 3:
                        Console.WriteLine("로그아웃 되었습니다.");
                        break;
                    default:
                        Console.WriteLine("번호를 잘못입력했어요");
                        professor_login();
                        break;
                }
                if (num == 3) break;
            }
        }
        private void student_login()
        {
            Console.WriteLine("학생 로그인 완료");
            while (true)
            {
                Console.WriteLine("-------메뉴------");
                Console.WriteLine("1.정보변경");
                Console.WriteLine("2.수강관리");
                Console.WriteLine("3.성적확인");
                Console.WriteLine("4.로그아웃");
                int num = int.Parse(Console.ReadLine());

                switch (num)
                {
                    case 1:
                        Console.WriteLine("정보변경 메뉴입니다.");
                        Console.Write("정보변경을 위해 학번을 재입력 해주세요:");
                        int ch_id = int.Parse(Console.ReadLine());
                        Person ch_student = PersonList.Find(x => x.ID == ch_id);
                        if (ch_id == login.id)
                        {
                            Student change_student = new Student();
                            Console.Write("전화번호:");
                            change_student.phoneNum = int.Parse(Console.ReadLine());
                            Console.Write("이메일:");
                            change_student.email = Console.ReadLine();
                            Console.Write("이름");
                            change_student.name = Console.ReadLine();
                            Console.Write("비밀번호:");
                            change_student.PW = Console.ReadLine();
                            var student = ch_student as Student;
                            student.modify(change_student);
                        }
                        else
                        {
                            Console.WriteLine("학번을 잘못 입력했습니다.");
                        }
                        break;
                    case 2:
                        Console.WriteLine("수강관리 메뉴입니다.");
                        Console.WriteLine("1.수강신청");
                        Console.WriteLine("2.수강변경");
                        Console.WriteLine("3.현재학기등록과목확인");
                        int num2 = int.Parse(Console.ReadLine());
                        Student ck_student = (PersonList.Find(x => x.ID == login.id)) as Student;
                        if (num2 == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("수강 신청 가능한 과목.");
                            for (int i = 0; i < subjectList.Count; i++)
                            {
                                Console.Write(subjectList[i].Name + " ");
                            }
                            Console.Write("수강 신청할 과목을 입력해주세요:");
                            string tmp_su = Console.ReadLine();
                            int tmp_subject = subjectList.FindIndex(x => x.Name == tmp_su);
                            subjectList[tmp_subject].Cstudent.Add(ck_student);

                        }
                        else if (num2 == 2)
                        {
                            Console.Clear();
                            Console.WriteLine("수강 신청된 과목입니다.");
                            Console.WriteLine("ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
                            int cnt = 0;
                            for (int i = 0; i < subjectList.Count - 1; i++)
                            {

                                Student st = subjectList[i].Cstudent.Find(x => x.ID == login.id);
                                if (st != null)
                                {
                                    cnt += 1;
                                    Console.WriteLine($"{cnt} - {subjectList[i].Name}");

                                }
                            }
                            Console.WriteLine("ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
                            Console.WriteLine("수강 취소할 과목을 입력해주세요.");
                            string ch_su = Console.ReadLine();
                            int ch_subject = subjectList.FindIndex(x => x.Name == ch_su);
                            if (ch_subject == -1)
                            {
                                Console.WriteLine("과목을 찾을수가없습니다");
                            }
                            else
                            {
                                subjectList[ch_subject].Cstudent.Remove(ck_student);
                            }
                        }
                        else if (num2 == 3)
                        {
                            Console.Clear();
                            Console.WriteLine("현재 학기 등록 과목입니다.");
                            Console.WriteLine("ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
                            int cnt = 0;
                            for (int i = 0; i < subjectList.Count; i++)
                            {
                                Student st = subjectList[i].Cstudent.Find(x => x.ID == login.id);
                                if (st != null)
                                {
                                    cnt += 1;
                                    Console.WriteLine($"{cnt} - {subjectList[i].Name}");
                                }
                            }
                            Console.WriteLine("ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
                        }
                        break;
                    case 3:
                        Console.WriteLine("성적확인 메뉴입니다.");
                        Console.WriteLine("1.과거 수강 과목");
                        Console.WriteLine("2.과거 수강 과목 성적 확인");
                        Console.WriteLine("3.학점 평균 확인");
                        int num3 = int.Parse(Console.ReadLine());
                        Console.Write("다시 한번 학번을 입력해주세요.");
                        int temp = int.Parse(Console.ReadLine());
                        Student ck_student1 = (PersonList.Find(x => x.ID == temp)) as Student;
                        if (temp == login.id)
                        {
                            if (num3 == 1)
                            {
                                foreach (var item in subjectEndList)
                                {
                                    var end = item.Cstudent.Find(x => x == ck_student1);
                                    if (end != null)
                                    {
                                        Console.WriteLine("과거 수강과목" + item.Name);
                                    }
                                }
                            }
                            else if (num3 == 2)
                            {
                                Console.WriteLine("과거 수강 과목 성적 입니다.");
                                foreach (var item in subjectEndList)
                                {
                                    var end = item.Cstudent.FindIndex(x => x == ck_student1);
                                    if (end != -1)
                                    {
                                        Console.WriteLine(item.Name + " : " + item.Cstudent[end].Grade);
                                    }
                                }
                            }
                            else if (num3 == 3)
                            {
                                int cnt = 0;
                                double arrange = 0;
                                Console.WriteLine("학점 평균 입니다.");
                                foreach (var item in subjectEndList)
                                {
                                    var end = item.Cstudent.FindIndex(x => x == ck_student1);
                                    if (end != -1)
                                    {
                                        Console.WriteLine(item.Name + " : " + item.Cstudent[end].Grade);
                                        cnt++;
                                        arrange += item.Cstudent[end].Grade;
                                    }
                                }
                                Console.Clear();
                                if (cnt == 0)
                                {
                                    Console.WriteLine("아직 학점이 나오지 않았습니다.");
                                }
                                else
                                {
                                    double divition = Math.Round(arrange / cnt, 2);
                                    Console.WriteLine("학점 평균: " + divition);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("학번을 잘못입력했습니다.");
                        }
                        break;
                    case 4:
                        Console.WriteLine("로그아웃 되었습니다.");
                        break;
                    default:
                        Console.WriteLine("번호를 잘못입력했어요");
                        student_login();
                        break;
                }
                
                if (num == 4) break;
            }
        }
    }
}


//로그인 클래스
class Login
{
    public int id { get; set; }
    public string pw { get; set; }
    public Permision per { get; set; }
    public Login(int Id, string pw, Permision per)
    {
        this.id = Id;
        this.pw = pw;
        this.per = per;
    }
}


