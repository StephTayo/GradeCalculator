using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CouseGradeCalculation
{
    /*
     * Letter grade:
     * Course grade 90 or more:           A
     *              80 or more, up to 90: B
     *              70 or more, up to 80: C
     *              60 or more, up to 70: D
     *              otherwise:            F
     */
    public partial class frmGrades : Form
    {
        // calculation constants
        const double QUIZZES_PCT = 0.3;
        const double MIDTERM_PCT = 0.3;
        const double FINAL_PCT = 0.4;
        const double A_LEVEL = 90;
        const double B_LEVEL = 80;
        const double C_LEVEL = 70;
        const double D_LEVEL = 60;
        public frmGrades()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            double quiz1;
            double quiz2;
            double quiz3;
            double midterm;
            double final;
            double lowestQuiz; // quiz to be dropped
            double adjustedQuizzes;// without the drop quiz
            double courseGrade;
            string letterGrade;

            // get individual grades
            quiz1 = Convert.ToDouble(txtQuiz1.Text);
            quiz2 = Convert.ToDouble(txtQuiz2.Text);
            quiz3 = Convert.ToDouble(txtQuiz3.Text);
            midterm = Convert.ToDouble(txtMidterm.Text);
            final = Convert.ToDouble(txtFinal.Text);

            // drop the lowest quiz
            //lowestQuiz = Math.Min(Math.Min(quiz1, quiz2), quiz3);
            lowestQuiz = quiz1;
            if(quiz2 < lowestQuiz) lowestQuiz = quiz2;
            if(quiz3 < lowestQuiz) lowestQuiz = quiz3;

            adjustedQuizzes = (quiz1 + quiz2 + quiz3 - lowestQuiz)/2;
            
            // calculate and display course grade
            courseGrade = adjustedQuizzes * QUIZZES_PCT +
                          midterm * MIDTERM_PCT +
                          final * FINAL_PCT;
            lblGrade.Text = courseGrade.ToString();

            // calculate and display letter grade
            if (courseGrade >= A_LEVEL)
                letterGrade = "A";
            else if (courseGrade >= B_LEVEL)
                letterGrade = "B";
            else if (courseGrade >= C_LEVEL)
                letterGrade = "C";
            else if (courseGrade >= D_LEVEL)
                letterGrade = "D";
            else
                letterGrade = "F";

            lblLetter.Text = letterGrade; // already a string
        }

        // erase data in preparation for next calculation
        private void btnErase_Click(object sender, EventArgs e)
        {
            txtQuiz1.Text = "";
            txtQuiz2.Text = "";
            txtQuiz3.Text = "";
            txtMidterm.Text = "";
            txtFinal.Text = "";
            lblGrade.Text = "";
            txtQuiz1.Focus();
        }
    }
}
