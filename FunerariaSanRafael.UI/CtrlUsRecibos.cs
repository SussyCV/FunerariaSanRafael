using FunerariaSanRafael.Models;
using FunerariaSanRafael.Models.DTO;
using Microsoft.Office.Interop.Excel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Globalization;
using System.Net;
using System.Text.Json;
using objExcel = Microsoft.Office.Interop.Excel;

namespace FunerariaSanRafael.UI
{
    public partial class CtrlUsRecibos : UserControl
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        mst_User usuario = new mst_User();
        public CtrlUsRecibos(mst_User usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        int? Exp;
        int? Periodo;
        List<mst_Recibo> Recibo = new List<mst_Recibo>();
        int Position = 0;
        string url = ConfigurationManager.AppSettings["baseApiURL"];

        public void Procedimiento()
        {

            var rec_periodo = Convert.ToInt32(udRecibosAnioGenera.Value.ToString() + cbRecibosMesGenera.Text);
            var userId = usuario.idUser;

            SqlConnection conSql = new SqlConnection();
            SqlCommand cmdSql = new SqlCommand();

            try
            {
                conSql.ConnectionString = ConfigurationManager.ConnectionStrings["fsrafael"].ConnectionString;

                if (conSql.State != ConnectionState.Open)
                {
                    conSql.Close();
                    conSql.Open();
                }

                cmdSql.Connection = conSql;
                cmdSql.CommandType = CommandType.StoredProcedure;
                cmdSql.CommandText = "dbo.CrearRecibos";
                cmdSql.Parameters.Add("@rec_periodo", SqlDbType.VarChar, 6).Value = rec_periodo.ToString();
                cmdSql.Parameters.Add("@userId", SqlDbType.VarChar, 15).Value = userId;

                SqlDataReader varReader = cmdSql.ExecuteReader();
                if (varReader.Read())
                {
                    var result = varReader[0];
                }

                MessageBox.Show("Recibos generados correctamente ", "Recibos", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception err)
            {
                MessageBox.Show("No se han podido generar los archivos \n Por favor inténtelo de nuevo \n" + err, "Error al generar recibos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                if (conSql.State == ConnectionState.Open)
                {
                    conSql.Close();
                    try
                    { cmdSql.Dispose(); }
                    catch { }
                }
            }
        }

        public void imprimirRecibos()
        {
            try
            {

                printDocument1 = new PrintDocument();
                PrinterSettings ps = new PrinterSettings();
                printDocument1.PrinterSettings = ps;
                PaperSize paperSize = new PaperSize("PapelContinuoTercioCarta", 215, 93); // Tamaño en milímetros
                printDocument1.DefaultPageSettings.PaperSize = paperSize;
                ObtenerListaRecibos();
                printDocument1.PrintPage += ImprimirTodos;
                printDialog1 = new PrintDialog();
                printDialog1.Document = printDocument1;
                DialogResult result = printDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    printDocument1.Print();
                    MessageBox.Show("Recibos impresos ", "Impresión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex1)
            {
                MessageBox.Show("No se ha podido imprimir el recibo \n Inténtelo de nuevo" + ex1, "Ha ocurrido un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void tablaImpresion()
        {
            try
            {
                var listarRecibo = (from Recibo in _context.mst_Recibo
                                    join Expediente in _context.mst_Expediente
                                    on Recibo.cod_expediente equals Expediente.cod_expediente
                                    select new
                                    {
                                        Recibo.cod_expediente,
                                        Expediente.exp_nombre,
                                        Expediente.idRuta,
                                        Recibo.rec_fechaPago,
                                        Recibo.rec_status,
                                        Recibo.rec_aporte_anterior,
                                        Recibo.rec_monto,
                                        Recibo.rec_deducciones,
                                        Recibo.rec_periodo,
                                        Recibo.updatedAt,
                                        Recibo.updatedBy,
                                        Recibo.numRecibo,
                                        Recibo.rec_fechaLiquidacion,
                                    }
                ).ToList();

                var listaImpresion = listarRecibo;

                //Flitra por periodo
                if ((!string.IsNullOrEmpty(cbRecibosMesBuscaDe.Text)) && (!string.IsNullOrEmpty(cbRecibosMesBuscaA.Text)))
                {
                    if ((cbRecibosMesBuscaDe.Text == "Todos") || (cbRecibosMesBuscaA.Text == "Todos"))
                    {

                    }
                    else
                    {
                        var rec_periodoDe = Convert.ToInt32(udRecibosAnioBuscaDe.Value.ToString() + cbRecibosMesBuscaDe.Text);
                        var rec_periodoA = Convert.ToInt32(udRecibosAnioBuscaA.Value.ToString() + cbRecibosMesBuscaA.Text);
                        listaImpresion = listaImpresion.Where(x => (x.rec_periodo >= rec_periodoDe && x.rec_periodo <= rec_periodoA)).ToList();
                    }
                }

                //Flitra por fecha de liquidacion
                if (cbImpresionStatus.Text == "Pagado")
                {
                    var desde = dtpRecibosDesde.Value;
                    desde = desde.AddDays(-1);
                    var hasta = dtpRecibosHasta.Value;
                    listaImpresion = listaImpresion.Where(x => (x.rec_fechaLiquidacion >= desde && x.rec_fechaLiquidacion <= hasta)).ToList();
                }

                //Flitra por ruta
                if (!string.IsNullOrEmpty(cbImpresionRuta.Text))
                {
                    listaImpresion = listaImpresion.Where(x => (x.idRuta == Convert.ToInt32(cbImpresionRuta.SelectedValue) || (cbImpresionRuta.SelectedValue.ToString() == "0"))).ToList();

                }

                //Flitra por expediente
                if (!string.IsNullOrEmpty(txtRecibosID.Text))
                {
                    listaImpresion = listaImpresion.Where(x => x.cod_expediente == Convert.ToInt32(txtRecibosID.Text)).ToList();
                }

                //Flitra por nombre
                if (!string.IsNullOrEmpty(txtRecibosNombre.Text))
                {
                    listaImpresion = listaImpresion.Where(x => x.exp_nombre.ToLower().Contains(txtRecibosNombre.Text.ToLower())).ToList();
                }

                //Flitra por status

                string sta = "";

                if (cbImpresionStatus.Text == "Pendiente de pago")
                {
                    sta = "A";
                }
                else if (cbImpresionStatus.Text == "Pagado")
                {
                    sta = "P";
                }

                if (!string.IsNullOrEmpty(cbImpresionStatus.Text))
                {
                    listaImpresion = listaImpresion.Where(x => (x.rec_status == sta) || (cbImpresionStatus.Text == "Todos")).ToList();

                }

                txtRecibosTotal.Text = listaImpresion.Sum(x => x.rec_monto).ToString("N");
                txtRecibosCantidad.Text = listaImpresion.Count.ToString();
                dgvImpresionCompleta.Visible = true;
                dgvImpresionCompleta.DataSource = listaImpresion;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se han podido cargar los datos \n Por favor inténtelo de nuevo \n" + ex, "Error en base de datos ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void editaTablaImpresion()
        {
            try
            {
                dgvImpresionCompleta.RowHeadersVisible = false;

                dgvImpresionCompleta.Columns["updatedAt"].Visible = false;
                dgvImpresionCompleta.Columns["updatedBy"].Visible = false;
                dgvImpresionCompleta.Columns["rec_fechaPago"].Visible = false;

                dgvImpresionCompleta.Columns["cod_expediente"].HeaderText = "Expediente";
                dgvImpresionCompleta.Columns["cod_expediente"].Width = 100;
                dgvImpresionCompleta.Columns["cod_expediente"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvImpresionCompleta.Columns["cod_expediente"].DisplayIndex = 2;

                dgvImpresionCompleta.Columns["exp_nombre"].HeaderText = "Nombre";
                dgvImpresionCompleta.Columns["exp_nombre"].Width = 400;
                dgvImpresionCompleta.Columns["exp_nombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvImpresionCompleta.Columns["exp_nombre"].DisplayIndex = 3;

                dgvImpresionCompleta.Columns["numRecibo"].HeaderText = "Doc #";
                dgvImpresionCompleta.Columns["numRecibo"].Width = 90;
                dgvImpresionCompleta.Columns["numRecibo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvImpresionCompleta.Columns["numRecibo"].DisplayIndex = 4;

                dgvImpresionCompleta.Columns["rec_periodo"].HeaderText = "Periodo";
                dgvImpresionCompleta.Columns["rec_periodo"].Width = 65;
                dgvImpresionCompleta.Columns["rec_periodo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvImpresionCompleta.Columns["rec_periodo"].DisplayIndex = 5;

                dgvImpresionCompleta.Columns["rec_aporte_anterior"].HeaderText = "Aporte anterior";
                dgvImpresionCompleta.Columns["rec_aporte_anterior"].Width = 150;
                dgvImpresionCompleta.Columns["rec_aporte_anterior"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvImpresionCompleta.Columns["rec_aporte_anterior"].DefaultCellStyle.Format = "N";
                dgvImpresionCompleta.Columns["rec_aporte_anterior"].DisplayIndex = 6;

                dgvImpresionCompleta.Columns["rec_monto"].HeaderText = "Monto";
                dgvImpresionCompleta.Columns["rec_monto"].Width = 125;
                dgvImpresionCompleta.Columns["rec_monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvImpresionCompleta.Columns["rec_monto"].DefaultCellStyle.Format = "N";
                dgvImpresionCompleta.Columns["rec_monto"].DisplayIndex = 7;

                dgvImpresionCompleta.Columns["rec_deducciones"].HeaderText = "Deducciones";
                dgvImpresionCompleta.Columns["rec_deducciones"].Width = 100;
                dgvImpresionCompleta.Columns["rec_deducciones"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvImpresionCompleta.Columns["rec_deducciones"].DefaultCellStyle.Format = "N";
                dgvImpresionCompleta.Columns["rec_deducciones"].DisplayIndex = 8;

                dgvImpresionCompleta.Columns["rec_status"].HeaderText = "Status";
                dgvImpresionCompleta.Columns["rec_status"].Width = 75;
                dgvImpresionCompleta.Columns["rec_status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvImpresionCompleta.Columns["rec_status"].DisplayIndex = 9;

                dgvImpresionCompleta.Columns["idRuta"].HeaderText = "Ruta";
                dgvImpresionCompleta.Columns["idRuta"].Width = 50;
                dgvImpresionCompleta.Columns["idRuta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvImpresionCompleta.Columns["idRuta"].DisplayIndex = 10;

                dgvImpresionCompleta.Columns["rec_fechaLiquidacion"].HeaderText = "Fecha de liquidación";
                dgvImpresionCompleta.Columns["rec_fechaLiquidacion"].Width = 125;
                dgvImpresionCompleta.Columns["rec_fechaLiquidacion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvImpresionCompleta.Columns["rec_fechaLiquidacion"].DisplayIndex = 11;

                dgvImpresionCompleta.Columns["Ver"].Visible = false;
                dgvImpresionCompleta.Columns["Ver"].Width = 50;
                dgvImpresionCompleta.Columns["Imprimir"].DisplayIndex = 0;
            }
            catch (Exception ex) { }
        }
        public void excel()
        {
            try
            {
                string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                objExcel.Application objAplicacion = new objExcel.Application();
                Workbook objLibro = objAplicacion.Workbooks.Add(XlSheetType.xlWorksheet);
                Worksheet objHoja = (Worksheet)objAplicacion.ActiveSheet;

                objAplicacion.Visible = false;

                foreach (DataGridViewColumn columna in dgvImpresionCompleta.Columns)
                {
                    objHoja.Cells[1, columna.Index + 1] = columna.HeaderText;
                    foreach (DataGridViewRow fila in dgvImpresionCompleta.Rows)
                    {
                        objHoja.Cells[fila.Index + 2, columna.Index + 1] = fila.Cells[columna.Index].Value;
                    }
                }
                sfdGuardar.DefaultExt = "*xlsx";
                sfdGuardar.FileName = "Recibos";
                sfdGuardar.Filter = "Libro de Excel (*.xlsx) | *.xlsx";

                if (sfdGuardar.ShowDialog() == DialogResult.OK)
                {
                    objLibro.SaveAs(sfdGuardar.FileName);
                    MessageBox.Show("Archivo guardado exitosamente", "Archivo exportado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                objLibro.Close();
                objAplicacion.Quit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido exportar el archivo \n Por favor inténtelo de nuevo \n" + ex, "Error al exportar el archivo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ParaImprimir(object sender, PrintPageEventArgs ev)
        {
            System.Drawing.Font headingFont = new System.Drawing.Font("Calibri", 13, System.Drawing.FontStyle.Bold);
            System.Drawing.Font boldFont = new System.Drawing.Font("Calibri", 11, System.Drawing.FontStyle.Bold);
            System.Drawing.Font normalFont = new System.Drawing.Font("Calibri", 11, System.Drawing.FontStyle.Regular);

            var Recibo = _context.mst_Recibo.Where(x => (x.cod_expediente == Exp) && (x.rec_periodo == Periodo)).FirstOrDefault();
            var Persona = _context.mst_Expediente.Where(x => x.cod_expediente == Exp).FirstOrDefault();
            var servicios = _context.rel_expediente_servicio.Where(x => x.cod_expediente == Exp).ToList();
            var nombreServicios = _context.mst_Servicio.ToList();
            var Rutas = _context.mst_Ruta.Where(x => x.idRuta == Recibo.idRuta).FirstOrDefault();

            string NumRecibo = Recibo.numRecibo.ToString();
            string fecha = Recibo.rec_fechaPago.ToShortDateString().ToString();
            string afiliado = Recibo.cod_expediente.ToString();
            string nombre = Persona.exp_nombre.ToString();
            string montoLetras = enletras(Recibo.rec_monto.ToString());
            string monto = Recibo.rec_monto.ToString("N");
            string aporteAnterior = Recibo.rec_aporte_anterior.ToString("N");

            decimal pruebaDeduccion = 0;
            if (Recibo.rec_deducciones.HasValue)
            {
                pruebaDeduccion = (decimal)Recibo.rec_deducciones;
            }
            string deducciones = pruebaDeduccion.ToString("N");
            string montoTotal = (Recibo.rec_monto + pruebaDeduccion).ToString("N");
            string aporteActual = (Recibo.rec_aporte_anterior + Recibo.rec_monto).ToString("N");
            string periodo = Recibo.rec_periodo.ToString();
            string anio = periodo.Substring(0, 4);
            string mesNum = periodo.Substring(4, 2);
            string mesLet = " ";
            string ruta = Recibo.idRuta.ToString();
            string cobrador = Rutas.ruta_nombre.ToString();

            string line = "-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
            float height = 20;
            float height2 = 280;

            switch (mesNum)
            {
                case "01":
                    mesLet = "Enero";
                    break;
                case "02":
                    mesLet = "Febrero";
                    break;
                case "03":
                    mesLet = "Marzo";
                    break;
                case "04":
                    mesLet = "Abril";
                    break;
                case "05":
                    mesLet = "Mayo";
                    break;
                case "06":
                    mesLet = "Junio";
                    break;
                case "07":
                    mesLet = "Julio";
                    break;
                case "08":
                    mesLet = "Agosto";
                    break;
                case "09":
                    mesLet = "Setiembre";
                    break;
                case "10":
                    mesLet = "Octubre";
                    break;
                case "11":
                    mesLet = "Noviembre";
                    break;
                case "12":
                    mesLet = "Diciembre";
                    break;
                default:
                    mesLet = " ";
                    break;
            }


            //Nombre princial
            ev.Graphics.DrawString("ASOCIACIÓN SERVICIOS FUNERARIOS SAN RAFAEL DE CORONADO", headingFont, Brushes.Black, 160, height, new StringFormat());
            height += 25;

            //Cedula
            ev.Graphics.DrawString("Cedula jurídica: 3-002-169580", boldFont, Brushes.Black, 10, height, new StringFormat());

            //Recibo
            ev.Graphics.DrawString("Recibo por dinero: " + NumRecibo, boldFont, Brushes.Black, 630, height, new StringFormat());
            height += 20;

            //Telefono
            ev.Graphics.DrawString("Tel – Fax: 2292-8392", boldFont, Brushes.Black, 10, height, new StringFormat());


            //Periodo
            ev.Graphics.DrawString("Periodo: " + mesLet + " " + anio, boldFont, Brushes.Black, 630, height, new StringFormat());
            height += 20;

            //Email
            ev.Graphics.DrawString("Email: funeraria.sanrafael@hotmail.com", boldFont, Brushes.Black, 10, height, new StringFormat());

            //Fecha
            ev.Graphics.DrawString("Fecha: " + fecha, boldFont, Brushes.Black, 630, height, new StringFormat());
            height += 25;

            //Expediente
            ev.Graphics.DrawString("Afiliado: " + afiliado, boldFont, Brushes.Black, 200, height, new StringFormat());

            //Nombre
            ev.Graphics.DrawString("Recibimos de: " + nombre, boldFont, Brushes.Black, 320, height, new StringFormat());
            height += 20;

            //En letras
            ev.Graphics.DrawString("La suma de: " + montoLetras + " COLONES", boldFont, Brushes.Black, 10, height, new StringFormat());
            height += 25;

            //Aporte anterior
            ev.Graphics.DrawString("Aporte liquidado: ", boldFont, Brushes.Black, 10, height, new StringFormat());
            ev.Graphics.DrawString(aporteAnterior, normalFont, Brushes.Black, 125, height, new StringFormat());

            //Este aporte
            ev.Graphics.DrawString("Cuota: ", boldFont, Brushes.Black, 235, height, new StringFormat());
            ev.Graphics.DrawString(monto, normalFont, Brushes.Black, 295, height, new StringFormat());

            //Aporte actual
            ev.Graphics.DrawString("Aporte actual: ", boldFont, Brushes.Black, 395, height, new StringFormat());
            ev.Graphics.DrawString(aporteActual, normalFont, Brushes.Black, 495, height, new StringFormat());

            //Recibido
            ev.Graphics.DrawString("Recibido: ", boldFont, Brushes.Black, 605, height, new StringFormat());
            ev.Graphics.DrawString(montoTotal, normalFont, Brushes.Black, 680, height, new StringFormat());
            height += 25;

            //Linea
            ev.Graphics.DrawString(line, normalFont, Brushes.Black, 10, height, new StringFormat());
            height += 10;


            //Titulos de servicios
            if (servicios.Count < 4)
            {
                ev.Graphics.DrawString("Servicio", boldFont, Brushes.Black, 220, height, new StringFormat());
                ev.Graphics.DrawString("Costo", boldFont, Brushes.Black, 430, height, new StringFormat());
                height += 10;
            }
            else
            {
                ev.Graphics.DrawString("Servicio", boldFont, Brushes.Black, 40, height, new StringFormat());
                ev.Graphics.DrawString("Costo", boldFont, Brushes.Black, 200, height, new StringFormat());
                ev.Graphics.DrawString("Servicio", boldFont, Brushes.Black, 520, height, new StringFormat());
                ev.Graphics.DrawString("Costo", boldFont, Brushes.Black, 660, height, new StringFormat());
                height += 10;
            }


            //Linea
            ev.Graphics.DrawString(line, normalFont, Brushes.Black, 10, height, new StringFormat());


            // Agrega servicios
            if (servicios.Count < 4)
            {
                foreach (var item in servicios)
                {
                    height += 20;
                    ev.Graphics.DrawString(nombreServicios.Where(x => x.idServicio == item.idServicio).FirstOrDefault().serv_desc.ToString(), normalFont, Brushes.Black, 220, height, new StringFormat());
                    ev.Graphics.DrawString(nombreServicios.Where(x => x.idServicio == item.idServicio).FirstOrDefault().serv_costo.ToString("N"), normalFont, Brushes.Black, 430, height, new StringFormat());

                }
            }
            else
            {
                int i = 0;
                foreach (var item in servicios)
                {

                    int width1 = 0;
                    int width2 = 0;
                    if (i % 2 == 0)
                    {
                        width1 = 20;
                        width2 = 190;
                        height += 20;
                    }
                    else
                    {

                        width1 = 500;
                        width2 = 670;

                    }
                    ev.Graphics.DrawString(nombreServicios.Where(x => x.idServicio == item.idServicio).FirstOrDefault().serv_desc.ToString(), normalFont, Brushes.Black, width1, height, new StringFormat());
                    ev.Graphics.DrawString(nombreServicios.Where(x => x.idServicio == item.idServicio).FirstOrDefault().serv_costo.ToString("N"), normalFont, Brushes.Black, width2, height, new StringFormat());

                    i++;
                }
            }

            //Linea
            ev.Graphics.DrawString(line, normalFont, Brushes.Black, 10, height2, new StringFormat());
            height2 += 20;

            //Recibido por
            ev.Graphics.DrawString("Recibido por: " + ruta + ". " + cobrador, boldFont, Brushes.Black, 350, height2, new StringFormat());
            height2 += 30;

            //Autorizado
            ev.Graphics.DrawString("Autorizado mediante oficio No. 01-0257-97 de fecha 26-09-97 de la D.G.T.D.", normalFont, Brushes.Black, 10, height2, new StringFormat());


            ev.HasMorePages = false;
        }

        private void ObtenerListaRecibos()
        {
            try
            {
                Position = 0;
                Recibo.Clear();
                var rec_periodo = Convert.ToInt32(udRecibosAnioGenera.Value.ToString() + cbRecibosMesGenera.Text);
                Recibo = _context.mst_Recibo.Where(x => x.rec_periodo == rec_periodo && x.idRuta == Convert.ToInt32(cbImpresionRutaBuscar.SelectedValue) || (cbImpresionRutaBuscar.SelectedValue.ToString() == "0")).ToList();
            }
            catch (Exception ex1)
            {

                MessageBox.Show("No se ha podido imprimir el recibo \n Inténtelo de nuevo" + ex1, "Ha ocurrido un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void ImprimirTodos(object sender, PrintPageEventArgs ev)
        {
            System.Drawing.Font headingFont = new System.Drawing.Font("Calibri", 13, System.Drawing.FontStyle.Bold);
            System.Drawing.Font boldFont = new System.Drawing.Font("Calibri", 11, System.Drawing.FontStyle.Bold);
            System.Drawing.Font normalFont = new System.Drawing.Font("Calibri", 11, System.Drawing.FontStyle.Regular);

            float height = 20;
            float height2 = 280;

            for (; Position < Recibo.Count; Position++)
            {


                if (height > ev.MarginBounds.Bottom)
                {
                    ev.HasMorePages = true;
                    return;
                }

                var Persona = _context.mst_Expediente.Where(x => x.cod_expediente == Recibo[Position].cod_expediente).FirstOrDefault();
                var servicios = _context.rel_expediente_servicio.Where(x => x.cod_expediente == Recibo[Position].cod_expediente).ToList();
                var nombreServicios = _context.mst_Servicio.ToList();
                var Rutas = _context.mst_Ruta.Where(x => x.idRuta == Recibo[Position].idRuta).FirstOrDefault();

                string NumRecibo = Recibo[Position].numRecibo.ToString();
                string fecha = Recibo[Position].rec_fechaPago.ToShortDateString().ToString();
                string afiliado = Recibo[Position].cod_expediente.ToString();
                string nombre = Persona.exp_nombre.ToString();
                string montoLetras = enletras(Recibo[Position].rec_monto.ToString());
                string monto = Recibo[Position].rec_monto.ToString("N");
                string aporteAnterior = Recibo[Position].rec_aporte_anterior.ToString("N");

                decimal pruebaDeduccion = 0;
                if (Recibo[Position].rec_deducciones.HasValue)
                {
                    pruebaDeduccion = (decimal)Recibo[Position].rec_deducciones;
                }
                string deducciones = pruebaDeduccion.ToString("N");
                string montoTotal = (Recibo[Position].rec_monto + pruebaDeduccion).ToString("N");
                string aporteActual = (Recibo[Position].rec_aporte_anterior + Recibo[Position].rec_monto).ToString("N");
                string periodo = Recibo[Position].rec_periodo.ToString();
                string anio = periodo.Substring(0, 4);
                string mesNum = periodo.Substring(4, 2);
                string mesLet = " ";
                string ruta = Recibo[Position].idRuta.ToString();
                string cobrador = Rutas.ruta_nombre.ToString();

                string line = "-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------";

                switch (mesNum)
                {
                    case "01":
                        mesLet = "Enero";
                        break;
                    case "02":
                        mesLet = "Febrero";
                        break;
                    case "03":
                        mesLet = "Marzo";
                        break;
                    case "04":
                        mesLet = "Abril";
                        break;
                    case "05":
                        mesLet = "Mayo";
                        break;
                    case "06":
                        mesLet = "Junio";
                        break;
                    case "07":
                        mesLet = "Julio";
                        break;
                    case "08":
                        mesLet = "Agosto";
                        break;
                    case "09":
                        mesLet = "Setiembre";
                        break;
                    case "10":
                        mesLet = "Octubre";
                        break;
                    case "11":
                        mesLet = "Noviembre";
                        break;
                    case "12":
                        mesLet = "Diciembre";
                        break;
                    default:
                        mesLet = " ";
                        break;
                }

                //Nombre princial
                ev.Graphics.DrawString("ASOCIACIÓN SERVICIOS FUNERARIOS SAN RAFAEL DE CORONADO", headingFont, Brushes.Black, 160, height, new StringFormat());
                height += 25; ;

                //Cedula
                ev.Graphics.DrawString("Cedula jurídica: 3-002-169580", boldFont, Brushes.Black, 10, height, new StringFormat());

                //Recibo
                ev.Graphics.DrawString("Recibo por dinero: " + NumRecibo, boldFont, Brushes.Black, 630, height, new StringFormat());
                height += 20;

                //Telefono
                ev.Graphics.DrawString("Tel – Fax: 2292-8392", boldFont, Brushes.Black, 10, height, new StringFormat());


                //Periodo
                ev.Graphics.DrawString("Periodo: " + mesLet + " " + anio, boldFont, Brushes.Black, 630, height, new StringFormat());
                height += 20;


                //Email
                ev.Graphics.DrawString("Email: funeraria.sanrafael@hotmail.com", boldFont, Brushes.Black, 10, height, new StringFormat());

                //Fecha
                ev.Graphics.DrawString("Fecha: " + fecha, boldFont, Brushes.Black, 630, height, new StringFormat());
                height += 25;


                //Expediente
                ev.Graphics.DrawString("Afiliado: " + afiliado, boldFont, Brushes.Black, 200, height, new StringFormat());

                //Nombre
                ev.Graphics.DrawString("Recibimos de: " + nombre, boldFont, Brushes.Black, 320, height, new StringFormat());
                height += 20;


                //En letras
                ev.Graphics.DrawString("La suma de: " + montoLetras + " COLONES", boldFont, Brushes.Black, 10, height, new StringFormat());
                height += 25;

                //Aporte anterior
                ev.Graphics.DrawString("Aporte liquidado: ", boldFont, Brushes.Black, 10, height, new StringFormat());
                ev.Graphics.DrawString(aporteAnterior, normalFont, Brushes.Black, 125, height, new StringFormat());

                //Este aporte
                ev.Graphics.DrawString("Cuota: ", boldFont, Brushes.Black, 235, height, new StringFormat());
                ev.Graphics.DrawString(monto, normalFont, Brushes.Black, 295, height, new StringFormat());

                //Aporte actual
                ev.Graphics.DrawString("Aporte actual: ", boldFont, Brushes.Black, 395, height, new StringFormat());
                ev.Graphics.DrawString(aporteActual, normalFont, Brushes.Black, 495, height, new StringFormat());

                //Recibido
                ev.Graphics.DrawString("Recibido: ", boldFont, Brushes.Black, 605, height, new StringFormat());
                ev.Graphics.DrawString(montoTotal, normalFont, Brushes.Black, 680, height, new StringFormat());
                height += 25;

                //Linea
                ev.Graphics.DrawString(line, normalFont, Brushes.Black, 10, height, new StringFormat());
                height += 10;


                //Titulos de servicios
                ev.Graphics.DrawString("Servicio", boldFont, Brushes.Black, 220, height, new StringFormat());
                ev.Graphics.DrawString("Costo", boldFont, Brushes.Black, 430, height, new StringFormat());
                height += 10;

                //Linea
                ev.Graphics.DrawString(line, normalFont, Brushes.Black, 10, height, new StringFormat());
                height += 20;

                // Agrega servicios
                if (servicios.Count < 4)
                {
                    foreach (var item2 in servicios)
                    {
                        ev.Graphics.DrawString(nombreServicios.Where(x => x.idServicio == item2.idServicio).FirstOrDefault().serv_desc.ToString(), normalFont, Brushes.Black, 220, height, new StringFormat());
                        ev.Graphics.DrawString(nombreServicios.Where(x => x.idServicio == item2.idServicio).FirstOrDefault().serv_costo.ToString("N"), normalFont, Brushes.Black, 430, height, new StringFormat());
                        height += 20;
                    }
                }
                //Linea
                ev.Graphics.DrawString(line, normalFont, Brushes.Black, 10, height2, new StringFormat());
                height2 += 20;

                //Recibido por
                ev.Graphics.DrawString("Recibido por: " + ruta + ". " + cobrador, boldFont, Brushes.Black, 350, height2, new StringFormat());
                height2 += 30;

                //Autorizado
                ev.Graphics.DrawString("Autorizado mediante oficio No. 01-0257-97 de fecha 26-09-97 de la D.G.T.D.", normalFont, Brushes.Black, 10, height2, new StringFormat());
                height = height2 + 50;
                height2 += 320;

            }
            ev.HasMorePages = false;
        }

        public string enletras(string num)
        {
            string res, dec = "";
            Int64 entero;
            int decimales;
            double nro;

            try
            {
                nro = Convert.ToDouble(num, CultureInfo.InvariantCulture);
            }
            catch
            {
                return "";
            }

            entero = Convert.ToInt64(Math.Truncate(nro));
            decimales = Convert.ToInt32(Math.Round((nro - entero) * 100, 2));
            if (decimales > 0)
            {
                dec = " CON " + decimales.ToString() + "/100";
            }

            res = aTexto(Convert.ToDouble(entero, CultureInfo.InvariantCulture)) + dec;
            return res;
        }
        private string aTexto(double value)
        {
            string Num2Text = "";
            value = Math.Truncate(value);
            if (value == 0) Num2Text = "CERO";
            else if (value == 1) Num2Text = "UNO";
            else if (value == 2) Num2Text = "DOS";
            else if (value == 3) Num2Text = "TRES";
            else if (value == 4) Num2Text = "CUATRO";
            else if (value == 5) Num2Text = "CINCO";
            else if (value == 6) Num2Text = "SEIS";
            else if (value == 7) Num2Text = "SIETE";
            else if (value == 8) Num2Text = "OCHO";
            else if (value == 9) Num2Text = "NUEVE";
            else if (value == 10) Num2Text = "DIEZ";
            else if (value == 11) Num2Text = "ONCE";
            else if (value == 12) Num2Text = "DOCE";
            else if (value == 13) Num2Text = "TRECE";
            else if (value == 14) Num2Text = "CATORCE";
            else if (value == 15) Num2Text = "QUINCE";
            else if (value < 20) Num2Text = "DIECI" + aTexto(value - 10);
            else if (value == 20) Num2Text = "VEINTE";
            else if (value < 30) Num2Text = "VEINTI" + aTexto(value - 20);
            else if (value == 30) Num2Text = "TREINTA";
            else if (value == 40) Num2Text = "CUARENTA";
            else if (value == 50) Num2Text = "CINCUENTA";
            else if (value == 60) Num2Text = "SESENTA";
            else if (value == 70) Num2Text = "SETENTA";
            else if (value == 80) Num2Text = "OCHENTA";
            else if (value == 90) Num2Text = "NOVENTA";
            else if (value < 100) Num2Text = aTexto(Math.Truncate(value / 10) * 10) + " Y " + aTexto(value % 10);
            else if (value == 100) Num2Text = "CIEN";
            else if (value < 200) Num2Text = "CIENTO " + aTexto(value - 100);
            else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) Num2Text = aTexto(Math.Truncate(value / 100)) + "CIENTOS";
            else if (value == 500) Num2Text = "QUINIENTOS";
            else if (value == 700) Num2Text = "SETECIENTOS";
            else if (value == 900) Num2Text = "NOVECIENTOS";
            else if (value < 1000) Num2Text = aTexto(Math.Truncate(value / 100) * 100) + " " + aTexto(value % 100);
            else if (value == 1000) Num2Text = "MIL";
            else if (value < 2000) Num2Text = "MIL " + aTexto(value % 1000);
            else if (value < 1000000)
            {
                Num2Text = aTexto(Math.Truncate(value / 1000)) + " MIL";
                if ((value % 1000) > 0) Num2Text = Num2Text + " " + aTexto(value % 1000);
            }

            else if (value == 1000000) Num2Text = "UN MILLON";
            else if (value < 2000000) Num2Text = "UN MILLON " + aTexto(value % 1000000);
            else if (value < 1000000000000)
            {
                Num2Text = aTexto(Math.Truncate(value / 1000000)) + " MILLONES ";
                if ((value - Math.Truncate(value / 1000000) * 1000000) > 0) Num2Text = Num2Text + " " + aTexto(value - Math.Truncate(value / 1000000) * 1000000);
            }

            else if (value == 1000000000000) Num2Text = "UN BILLON";
            else if (value < 2000000000000) Num2Text = "UN BILLON " + aTexto(value - Math.Truncate(value / 1000000000000) * 1000000000000);

            else
            {
                Num2Text = aTexto(Math.Truncate(value / 1000000000000)) + " BILLONES";
                if ((value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0) Num2Text = Num2Text + " " + aTexto(value - Math.Truncate(value / 1000000000000) * 1000000000000);
            }
            return Num2Text;

        }
        public static string apiClientes(string url)
        {
            string result = "";
            WebRequest oRequest = WebRequest.Create(url);
            oRequest.Method = "POST";
            oRequest.ContentType = "application/json";
            oRequest.Headers.Add("Authorization", ConfigurationManager.AppSettings["token"]);

            using (var oSW = new StreamWriter(oRequest.GetRequestStream()))
            {
                string json = "{\"mod\": \"Client\", \"fn\": \"getFiles\", \"dbName\": \"fsrafael\"}";

                oSW.Write(json);
                oSW.Flush();
                oSW.Close();
            }

            WebResponse oResponse = oRequest.GetResponse();
            using (var oSR = new StreamReader(oResponse.GetResponseStream()))
            {

                result = oSR.ReadToEnd().Trim();
            }
            return result;
        }
        public void sincronizar()
        {
            try
            {
                ApplicationDbContext _context2 = new ApplicationDbContext();
                ResponseGetClients clientes = JsonSerializer.Deserialize<ResponseGetClients>(apiClientes(url));
                var expedientes = _context2.mst_Expediente.ToList();


                int expCount = 0;
                int saldoCount = 0;

                if (clientes != null)
                {
                    foreach (var item in clientes.data)
                    {
                        var existe = false;
                        foreach (var exp in expedientes)
                        {
                            if (item.id == exp.cod_expediente)
                            {
                                existe = true;
                                if (Convert.ToDecimal(item.amount_avail, CultureInfo.InvariantCulture) != exp.exp_saldo)
                                {
                                    exp.exp_saldo = Convert.ToDecimal(item.amount_avail, CultureInfo.InvariantCulture);
                                    saldoCount++;
                                }
                            }
                        }
                        if (!existe)
                        {
                            mst_Expediente nuevoExpediente = new mst_Expediente()
                            {
                                cod_expediente = item.id,
                                exp_saldo = Convert.ToDecimal(item.amount_avail, CultureInfo.InvariantCulture),
                                idRuta = 1,
                                exp_status = 'A',
                                createdAt = DateTime.Now,
                                createdBy = usuario.idUser.ToString(),
                                updatedAt = null,
                                updatedBy = null,
                                exp_nombre = item.name,
                                exp_email = item.email,
                                exp_celular = item.paxphone,
                                exp_telefono = null,
                                exp_cedula = item.idnum,
                                exp_provincia = null,
                                exp_fec_ini_contrato = DateTime.Parse(item.datein),
                                exp_direccion = null,
                                exp_fec_utlimo_abono = null,
                                exp_categoria = null,
                                exp_comentarios = item.requested,
                            };

                            var newExpediente = _context.mst_Expediente.Add(nuevoExpediente);
                            expCount++;
                        }
                    }
                }
                _context.SaveChanges();
                _context2.SaveChanges();
                MessageBox.Show("Se han agregado " + expCount + " afiliados nuevos. \nSe han actualizado " + saldoCount + " expedientes.", "Datos sincronizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido acceder a la base de datos \n Por favor inténtelo de nuevo \n" + ex, "Error en base de datos ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btndtImpresionBuscar_Click(object sender, EventArgs e)
        {
            tablaImpresion();
            editaTablaImpresion();
        }

        private void cbImpresionRuta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtRecibosID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CtrlUsRecibos_Load(object sender, EventArgs e)
        {
            try
            {
                dgvImpresionCompleta.Visible = false;

                // ComboBox RUTA
                var combo = _context.mst_Ruta.ToList();
                combo.Add(new mst_Ruta() { idRuta = 0, ruta_nombre = "Todas" });
                List<mst_Ruta> comboOrden = combo.OrderBy(x => x.idRuta).ToList();

                cbImpresionRuta.DataSource = comboOrden;
                //campo que vera el usuario
                cbImpresionRuta.DisplayMember = "ruta_nombre";
                //campo que es el valor real
                cbImpresionRuta.ValueMember = "idRuta";

                // ComboBox RUTA
                var combo1 = _context.mst_Ruta.ToList();
                combo1.Add(new mst_Ruta() { idRuta = 0, ruta_nombre = "Todas" });
                List<mst_Ruta> comboOrden1 = combo1.OrderBy(x => x.idRuta).ToList();

                cbImpresionRutaBuscar.DataSource = comboOrden1;
                //campo que vera el usuario
                cbImpresionRutaBuscar.DisplayMember = "ruta_nombre";
                //campo que es el valor real
                cbImpresionRutaBuscar.ValueMember = "idRuta";

                DateTime fecha = DateTime.Now;
                string s = fecha.Month.ToString();
                cbRecibosMesGenera.SelectedIndex = fecha.Month;
                cbRecibosMesBuscaDe.SelectedIndex = fecha.Month;
                cbRecibosMesBuscaA.SelectedIndex = fecha.Month;
                udRecibosAnioGenera.Value = fecha.Year;
                udRecibosAnioBuscaDe.Value = fecha.Year;
                udRecibosAnioBuscaA.Value = fecha.Year;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido acceder a la base de datos \n Por favor inténtelo de nuevo \n" + ex, "Error en carga de datos ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            tablaImpresion();
            editaTablaImpresion();
        }


        private void btnRecibosGenerar_Click(object sender, EventArgs e)
        {
            sincronizar();
            Procedimiento();
        }

        private void btnImpresionImprimir_Click(object sender, EventArgs e)
        {
            excel();
        }

        private void dgvImpresionCompleta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0) // Valida que se le dio clik a la celda en posición 0 (Imprimir)
                {


                    Exp = Convert.ToInt32(dgvImpresionCompleta.Rows[e.RowIndex].Cells["cod_expediente"].Value);
                    Periodo = Convert.ToInt32(dgvImpresionCompleta.Rows[e.RowIndex].Cells["rec_periodo"].Value);
                    try
                    {
                        var listar = _context.mst_Recibo.Where(x => (x.cod_expediente == Exp) && (x.rec_periodo == Periodo)).FirstOrDefault();

                        printDocument1 = new PrintDocument();
                        PrinterSettings ps = new PrinterSettings();
                        printDocument1.PrinterSettings = ps;
                        printDocument1.PrintPage += ParaImprimir;
                        printDialog1 = new PrintDialog();
                        printDialog1.Document = printDocument1;
                        DialogResult result = printDialog1.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            printDocument1.Print();
                        }

                    }
                    catch (Exception ex1)
                    {
                        MessageBox.Show("No se ha podido imprimir el recibo \n Inténtelo de nuevo \n" + ex1, "Ha ocurrido un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Exp = null;
                    Periodo = null;
                }
            }
            catch (Exception ex) { }


        }

        private void btndtImpresionImprimir_Click(object sender, EventArgs e)
        {
            imprimirRecibos();
        }
    }
}