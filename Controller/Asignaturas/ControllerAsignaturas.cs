using Refuerzo2024.Model.DAO;
using Refuerzo2024.View.Asignaturas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Refuerzo2024.Controller.Asignaturas
{
    internal class ControllerAsignaturas
    {

        ViewAsignaturas objAsignaturas;
        public ControllerAsignaturas(ViewAsignaturas objAsignaturas)
        {
            objAsignaturas.Load += new EventHandler(CargaInicial);
            objAsignaturas.btnAgregar.Click += new EventHandler(RegistrarAsignaturas);
            objAsignaturas.btnActualizar.Click += new EventHandler(ActualizarAsignaturas);
            objAsignaturas.btnEliminar.Click += new EventHandler(EliminarAsignaturas);
            objAsignaturas.btnBuscar.Click += new EventHandler(BuscarAsignaturas);

        }


        public void CargaInicial(object sender, EventArgs e)
        {
            LlenarComboEspecialidades();
            LlenarDataGridViewAsignaturas();
        }
        private void LlenarComboEspecialidades()
        {
            DAOEstudiantes obj = new DAOEstudiantes();
            DataSet ds = obj.ObtenerEspecialidades();
            objAsignaturas.cmbEspecialidad.DataSource = ds.Tables["Especialidades"];
            objAsignaturas.cmbEspecialidad.DisplayMember = "nombreEspecialidad";
            objAsignaturas.cmbEspecialidad.ValueMember = "idEspecialidad";
        }

        private void LlenarDataGridViewAsignaturas()
        {
            DAOAsignaturas obj = new DAOAsignaturas();
            DataSet ds = obj.ObtenerAsignaturas();
            objAsignaturas.dgvAsignaturas.DataSource = ds.Tables["Asignaturas"];
        }


        public void RegistrarAsignaturas(object sender, EventArgs e)
        {
            DAOAsignaturas data = new DAOAsignaturas();
            data.NombreAsignaruras = objAsignaturas.txtNombreAsignatura.Text.Trim();
            data.Codigo = objAsignaturas.txtCodigoAsignatura.Text.Trim();
            data.Facultad1 = objAsignaturas.txtFacultad.Text.Trim();
            data.IdEspecialidad = (int)objAsignaturas.cmbEspecialidad.SelectedValue;

            if (data.RegistrarAsignaturas() == true)
            {
                MessageBox.Show("Datos registrados correctamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar los datos", "Proceso incompleto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public void ActualizarAsignaturas(object sender, EventArgs e)
        {
            DAOAsignaturas data = new DAOAsignaturas();
            data.IdAsignaturas = int.Parse(objAsignaturas.txtID.Text.Trim().ToString());
            data.NombreAsignaruras = objAsignaturas.txtNombreAsignatura.Text.Trim();
            data.Codigo = objAsignaturas.txtCodigoAsignatura.Text.Trim();
            data.Facultad1 = objAsignaturas.txtFacultad.Text.Trim();
            data.IdEspecialidad = (int)objAsignaturas.cmbEspecialidad.SelectedValue;
            if (data.ActualizarAsignaturas() == true)
            {
                MessageBox.Show("Los datos fueron actualizados correctamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LlenarDataGridViewAsignaturas();
            }
            else
            {
                MessageBox.Show("Los datos no pudieron ser actualizados.", "Proceso interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public void EliminarAsignaturas(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(objAsignaturas.txtID.Text.Trim()))
            {
                MessageBox.Show("Seleccione un registro", "Seleccione un valor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DAOAsignaturas data = new DAOAsignaturas();
                data.IdAsignaturas = int.Parse(objAsignaturas.txtID.Text);
                if (MessageBox.Show("¿Desea eliminar el registro seleccionado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (data.EliminarAsignaturas() == true)
                    {
                        MessageBox.Show("El dato fue eliminado correctamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LlenarDataGridViewAsignaturas();
                    }
                    else
                    {
                        MessageBox.Show("El registro no pudo ser eliminado", "Proceso interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        public void BuscarAsignaturas(object sender, EventArgs e)
        {
            DAOEstudiantes data = new DAOEstudiantes();
            DataSet ds = data.BuscarEstudiante(objAsignaturas.txtBuscar.Text.Trim());
            objAsignaturas.dgvAsignaturas.DataSource = ds.Tables["Asignaturas"];
        }
    }
}
