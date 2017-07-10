using System;
using System.Drawing;
using System.Windows.Forms;

namespace QRCode_CODESP
{
    public partial class frmGerador : Form
    {
        public frmGerador()
        {
            InitializeComponent();
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            string informacoes = txtInfo.Text.TrimEnd().TrimStart();

            if (informacoes == String.Empty)
                MessageBox.Show("O campo informações é obrigatório", "Administrador");
            else
                picQRCode.Image = QRCode(200, 200, txtInfo.Text);
        }

        private Bitmap QRCode(int v1, int v2, string text)
        {
            try
            {
                ZXing.BarcodeWriter bw = new ZXing.BarcodeWriter();
                ZXing.Common.EncodingOptions encOptions = new ZXing.Common.EncodingOptions()
                {
                    Height = v1,
                    Width = v2,
                    Margin = 0
                };
                bw.Format = ZXing.BarcodeFormat.QR_CODE;
                Bitmap imagem = new Bitmap(bw.Write(text));
                return imagem;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Administrador");
                throw;
            }
        }
    }
}
