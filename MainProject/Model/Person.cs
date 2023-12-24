using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Model
{
   abstract  class Person
    {
        //학번 , 사번
        public abstract  int ID { get; set; }

        //전화번호
        public abstract  int phoneNum { get; set; }

        //이메일
        public abstract string email { get; set; }

        //이름
        public abstract string name { get; set; }

        //소속부서 / 소속 학과
        public abstract string divison { get; set; }
        //비밀번호
        public abstract string PW { get; set; }


    }
    class root : Person
    {
        public override int ID { get; set; }
        public override int phoneNum { get; set; }
        public override string email { get; set; }
        public override string name { get; set; }
        public override string divison { get; set; }
        public override string PW { get; set; }
        public bool isSuper { get; set; }
        
        public root(int id, int phoneNum, string email, string name, string divison, string pw,bool isSuper)
        {
            this.ID = id;
            this.phoneNum = phoneNum;
            this.email = email;
            this.name = name;
            this.divison = divison;
            this.PW = pw;
            this.isSuper = isSuper;
        }
        

    }
    class Student:Person, IMethod
    {
        public override int ID { get; set; }
        public override int phoneNum { get; set; }
        public override string email { get; set; }
        public override string name { get; set; }
        public override string divison { get; set; }
        public override string PW { get; set; }
        public string scholarShip { get; set; }
        public double Grade { get; set; }
        public Student()
        {

        }

        public Student(int id,int phoneNum,string email,string name, string divison,string pw,string scholarShip,double Grade)
        {
            this.ID = id;
            this.phoneNum = phoneNum;
            this.email = email;
            this.name = name;
            this.divison = divison;
            this.PW = pw;
            this.scholarShip = scholarShip;
            this.Grade = Grade;
        }
        public void modify(object value)
        {
            Student x = value as Student;

            this.phoneNum = x.phoneNum;
            this.email = x.email;
            this.divison = x.divison;
            this.scholarShip = x.scholarShip;
            this.Grade = x.Grade;
            this.name = x.name;
            this.PW = x.PW;
        }
    }

    abstract class Faculty : Person
    {
        public override int ID { get; set; }
        public override int phoneNum { get; set; }
        public override string email { get; set; }
        public override string name { get; set; }
        public override string divison { get; set; }
        public override string PW { get; set; }
        //월급여
        public virtual int payMent { get; set; }
        //강의과목
        public virtual string teachSub { get; set; }
        //직급
        public virtual string rank { get; set; }
        //입사일
        public abstract string entryDate { get; set; }

    }
}


