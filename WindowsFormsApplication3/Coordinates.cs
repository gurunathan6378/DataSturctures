﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Coordinates : Form
    {
        public Coordinates()
        {
            InitializeComponent();
        }

        private void btn_Find_a_king_is_threatened_by_queen_in_a_cheese_board_Click(object sender, EventArgs e)
        {
            int kr, kc, qr, qc = 0;
            kr = 3; kc = 8;
            qr = 0; qc = 3;
            bool kingIsThreadByQueen = false;

            if (kr >= 0 && kr <= 7 && kc >= 0 && kc <= 7 && qr >= 0 && qr <= 7 && qc >= 0 && qc <= 7)
            {

                if (kr == qr || kc == qc || (Math.Abs(kr - qr) == Math.Abs(kc - qc)))
                {
                    kingIsThreadByQueen = true;
                }

                MessageBox.Show($"King is {(kingIsThreadByQueen ? "" : "not")} threatened by Queen");
            }
            else
            {
                MessageBox.Show($"Invalid inputs King row {kr.ToString()} and King column {kc.ToString()} \n  Queen row {qr.ToString()} and Queen column {qc.ToString()}  ");
            }
        }

        private bool IsSafe(int row, int column, Tuple<int, int>[,] queens)
        {
           for(int i = 0; i<queens.Length; i++)
            {
                
            }
            return false;
        }


        private bool PlaceQueens(int col)
        {
            return true;
        }

        private void N_Queens_Backtracking_Algorithm_Click(object sender, EventArgs e)
        {
            int[,] queens = new int[3, 3];


            



        }
    }
}