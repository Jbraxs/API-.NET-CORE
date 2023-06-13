using CrudWindowsForm.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CrudWindowsForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Refrescar();

        }

        #region HELPER
        private void Refrescar()
        {
            using (CrudEntities db = new CrudEntities())
            {
                var lst = from d in db.tabla
                          select d;
                dataGridView1.DataSource = lst.ToList();
            }
        }

        private int? GetId()
        {
            try
            {
                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {
                return null;
            }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            Presentation.FrmTabla oFrmTabla = new Presentation.FrmTabla();
            oFrmTabla.ShowDialog();

            Refrescar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            if (id != null)
            {
                Presentation.FrmTabla oFrmTabla = new Presentation.FrmTabla(id);
                oFrmTabla.ShowDialog();

                Refrescar();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            if (id != null)
            {
                using (CrudEntities db= new CrudEntities())
                {
                    tabla oTabla = db.tabla.Find(id);
                    db.tabla.Remove(oTabla);

                    db.SaveChanges();
                }
                Refrescar();
            }
        }
    }
}
