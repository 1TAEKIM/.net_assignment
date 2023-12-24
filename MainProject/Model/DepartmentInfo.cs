using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Model
{

    class DepartmentInfo : IMethod
    {
        //학과명
        public string name { get; set; }
        //주소
        public string address { get; set; }

        //전화번호
        public int phone { get; set; }
        //조교명
        public string assistentName { get; set; }
        //학과장명
        public string headName { get; set; }
        //이메일
        public string email { get; set; }

        //웹사이트
        public string webSite { get; set; }

        //소속교수
        public List<Professor> TProfessor { get; set; }
        //소속 학생
        public List<Student> TStudent { get; set; }
        public DepartmentInfo()
        {

        }
        public DepartmentInfo(string name, string address, int phone, string assistentName, string headName, string email, string webstie, List<Professor> Tprofessor, List<Student> tStudent)
        {
            this.name = name;
            this.address = address;
            this.phone = phone;
            this.assistentName = assistentName;
            this.headName = headName;
            this.email = email;
            this.webSite = webstie;
            this.TProfessor = Tprofessor;
            this.TStudent = tStudent;
        }
        public void modify(object value)
        {
            DepartmentInfo x = value as DepartmentInfo;
            this.name = x.name;
            this.address = x.address;
            this.phone = x.phone;
            this.assistentName = x.assistentName;
            this.headName = x.headName;
            this.email = x.email;
            this.webSite = x.webSite;
            this.TProfessor = x.TProfessor;
            this.TStudent = x.TStudent;
        }
    }

    //과목정보 클래스
    class Subject
    {
        //과목코드
        public int code { get; set; }
        //과목이름
        public string Name { get; set; }
        // 교수 배정
        public Professor allowProfessor { get; set; }
        // 강의실 변경
        public string lectureRoom { get; set; }
        // 학생 수강 등록
        public List<Student> Cstudent { get; set; }

        public Subject()
        {

        }
        public Subject(int code, string Name, Professor allowProfessor, string lectureRoom, List<Student> Cstudent)
        {
            this.code = code;
            this.Name = Name;
            this.allowProfessor = allowProfessor;
            this.lectureRoom = lectureRoom;
            this.Cstudent = Cstudent;
        }
    }

    struct SubjectEnd
    {
        //과목코드
        public int code { get; set; }
        //과목이름
        public string Name { get; set; }
        // 교수 배정
        public Professor allowProfessor { get; set; }
        // 강의실 변경
        public string lectureRoom { get; set; }
        // 학생 수강 등록
        public List<Student> Cstudent { get; set; }


        public SubjectEnd(int code, string Name, Professor allowProfessor, string lectureRoom, List<Student> Cstudent)
        {
            this.code = code;
            this.Name = Name;
            this.allowProfessor = allowProfessor;
            this.lectureRoom = lectureRoom;
            this.Cstudent = Cstudent;
        }
    }

}