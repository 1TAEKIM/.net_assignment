using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Model
{
    //조교
    class Assistant:Faculty,IMethod
    {
        public override int ID { get; set; }
        public override int phoneNum { get; set; }
        public override string email { get; set; }
        public override string name { get; set; }
        public override string divison { get; set; }
        public override string PW { get; set; }
        public override string entryDate { get; set; }
        public Assistant(int id, int phoneNum, string email, string name, string divison,string pw, int payMent, string teachSub, string rank, string entryDate) 
        {
            //사번
            this.ID = id;
            //휴대폰번호
            this.phoneNum = phoneNum;
            //이메일
            this.email = email;
            //이름
            this.name = name;
            //소속부서
            this.divison = divison;
            this.PW = pw;
            //월급여
            this.payMent = payMent;
            //조교배당 과목
            this.teachSub = teachSub;
            //입사일
            this.entryDate = entryDate;
        }
        public void modify(object value)
        {
            Assistant x = value as Assistant;

            this.phoneNum = x.phoneNum;
            this.email = x.email;
            this.divison = x.divison;
            this.payMent = x.payMent;
            this.teachSub = x.teachSub;

        }
    }

    class Staff:Faculty, IMethod
    {

        public override int ID { get; set; }
        public override int phoneNum { get; set; }
        public override string email { get; set; }
        public override string name { get; set; }
        public override string divison { get; set; }
        public override string rank { get; set; }
        public override string PW { get; set; }
        public override string entryDate { get; set; }

        public Staff(int id, int phoneNum, string email, string name, string divison, string pw,int payMent, string teachSub, string rank, string entryDate)
        {
            //사번
            this.ID = id;
            //휴대폰번호
            this.phoneNum = phoneNum;
            //이메일
            this.email = email;
            //이름
            this.name = name;
            //소속부서
            this.divison = divison;
            this.PW = pw;
            //월급여
            this.payMent = payMent;
            this.teachSub = teachSub;
            //직급
            this.rank = rank;
            //입사일
            this.entryDate = entryDate;
        }

        public void modify(object value)
        {
            Staff x = value as Staff;

            this.phoneNum = x.phoneNum;
            this.email = x.email;
            this.divison = x.divison;
            this.payMent = x.payMent;
            this.rank = x.rank;

        }
    }

    //교수
    class Professor :Faculty, IMethod
    {
        public override int ID { get; set; }
        public override int phoneNum { get; set; }
        public override string email { get; set; }
        public override string name { get; set; }
        public override string divison { get; set; }
        public override string rank { get; set; }
        public override string PW { get; set; }
        public override string entryDate { get; set; }
        public Professor()
        {

        }
        public Professor(int id, int phoneNum, string email, string name, string divison,string pw, int payMent, string teachSub, string rank, string entryDate)
        {
            //사번
            this.ID = id;
            //휴대폰번호
            this.phoneNum = phoneNum;
            //이메일
            this.email = email;
            //이름
            this.name = name;
            //소속부서
            this.divison = divison;

            this.PW = pw;
            //월급여
            this.payMent = payMent;
            //강의 과목
            this.teachSub = teachSub;
            //직급
            this.rank = rank;
            //입사일
            this.entryDate = entryDate;
        }

        public void modify(object value)
        {
            Professor x = value as Professor;

            this.phoneNum = x.phoneNum;
            this.email = x.email;
            this.divison = x.divison;
            this.payMent = x.payMent;
            this.teachSub = x.teachSub;
            this.rank = x.rank;
            this.name = x.name;
            this.PW = x.PW;

        }
    }
}
