using System;
using System.Windows.Forms;

namespace MaquinaCafeVirtual
{
    public partial class frmMaquinaCafeVirtual : Form
    {
        double valor =0 , valorProduto = 0;
        int opcao = 0;
        public frmMaquinaCafeVirtual()
        {
            InitializeComponent();
        }

        private void pct_Cafe_Click(object sender, EventArgs e)
        {
            opcao = 1;
            EscolherOpcao(opcao);
        }

        private void pct_mocha_Click(object sender, EventArgs e)
        {
            opcao = 2;
            EscolherOpcao(opcao);
        }

        private void pct_Cappucino_Click(object sender, EventArgs e)
        {
            opcao = 3;
            EscolherOpcao(opcao);
        }

        private void pct_CafeLeite_Click(object sender, EventArgs e)
        {
            opcao = 4;        
            EscolherOpcao(opcao);
        }

        private void pct_UmRealMoeda_Click_1(object sender, EventArgs e)
        {
            valor += 1.0;
            AtulizarValor(valor);
        }

        private void pct_CinquentaCentavos_Click_1(object sender, EventArgs e)
        {
            valor += 0.5;
            AtulizarValor(valor);
        }

        private void pct_VinteCincoCentavos_Click_1(object sender, EventArgs e)
        {
            valor += 0.25;
            AtulizarValor(valor);
        }

        private void pct_DezCentavos_Click_1(object sender, EventArgs e)
        {
            valor += 0.10;
            AtulizarValor(valor);
        }

        private void pct_CincoCentavos_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Moeda indisponível!", "Atenção!");
        }

        private void pct_UmCentavo_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Não mais comercializavel!", "Atenção!");
        }
        //Método para atualizar o valor que o usuário inserir por meio de moedas.
        public void AtulizarValor(double valor)
        {
            //Formatação para uma string no valor de moeda, com duas casas após a vírgula.
            lbl_Valor.Text = Convert.ToString(valor.ToString("N2"));
        }
        //Método para gerar o troco.
        public void Troco(double valor)
        {
            //Comando para determinar a moeda e quantas casas após a vírgula
            lblTroco.Text = valor.ToString("N2");
            //O método também verifica se o usuário tem que receber troco
            if (valor > 0)
            {
                MessageBox.Show("Troco: R$" + valor.ToString("N2"), "\tReceber Troco");
            }
            else
            {
                MessageBox.Show("Não há troco!", "Não há troco");
            }
        }
        //Método para limpar as variáveis (valor e valorProduto) e atualizar o label de valor
        public void LimparValores()
        {
            valor = 0;
            lbl_Valor.Text = valor.ToString("N2");
            lblTroco.Text = valor.ToString("N2");
            valorProduto = 0;
        }
        //Método que selecionará a opção selecionada pelo usuário
        public void EscolherOpcao(int opcao)
        {
            switch (opcao)
            {
                case 1:
                    valorProduto = 2.00;
                    ComprarProduto(valor, valorProduto);
                    break;
                case 2:
                    valorProduto = 4.00;
                    ComprarProduto(valor, valorProduto);
                    break;
                case 3:
                    valorProduto = 3.50;
                    ComprarProduto(valor, valorProduto);
                    break;
                case 4:
                    valorProduto = 3.00;
                    ComprarProduto(valor, valorProduto);
                    break;
            }
        }
        //Botão que usa o método LimparValores, para corrigir o saldo do usuário.
        private void btnCorrigirSaldo_Click(object sender, EventArgs e)
        {
            LimparValores();
        }
        //Botão para sair da aplicação
        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }
        /*Método que fará a comparação do valor inserido pelo usuário e o preço do produto,
            onde terá a disponibilidade de realizar a compra ou não.*/
        public void ComprarProduto(double valor, double valorProduto)
        {
            if (valor >= valorProduto)
            {
                var result = MessageBox.Show("Confirmar compra?", "Confirmação de Compra",
                         MessageBoxButtons.YesNo,
                         MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    valor -= valorProduto;
                    Troco(valor);
                    LimparValores();
                }
            }
            else
            {
                MessageBox.Show("Valor digitado não corresponde ao preço do produto!");
            }
        }
    }
}
