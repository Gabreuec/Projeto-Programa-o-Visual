using System;
using System.Windows.Forms;

namespace Aula_4
{
    public partial class Form1 : Form
    {
        
        double valor = 0;               // Armazena o valor acumulado nas opera��es
        string operacao_pendente = "";  // Guarda a opera��o (+, -, *, /)
        bool resolver_operacao = false; // Controla quando deve limpar o visor

        public Form1()
        {
            InitializeComponent();  // M�todo gerado automaticamente que inicializa os componentes do formul�rio
        }

        private void txt_Visor_TextChanged(object sender, EventArgs e)
        {
            // Evento que ocorre quando o texto no visor � alterado
            // Pode ser usado para valida��es adicionais
        }

        // M�todo para tratar opera��es matem�ticas
        public void operacao(String valor_operacao)
        {
            // Se j� houver uma opera��o pendente e n�o for um novo c�lculo
            if (operacao_pendente != "" && !resolver_operacao)
            {
                btn_calcular.PerformClick(); // Executa o c�lculo da opera��o pendente
            }

            valor = double.Parse(txt_Visor.Text); // Converte o valor do visor para double
            operacao_pendente = valor_operacao;   // Armazena a nova opera��o
            resolver_operacao = true;             // Sinaliza para limpar o visor no pr�ximo n�mero
        }

        // M�todo para tratar d�gitos pressionados
        public void funcao_inicial_Botao(String valor_botao)
        {
            // Se o visor mostrar "0" ou for uma nova opera��o
            if (txt_Visor.Text == "0" || resolver_operacao == true)
            {
                txt_Visor.Clear();        // Limpa o visor
                resolver_operacao = false; // Reseta o flag(indicador)
            }

            // Impede m�ltiplas v�rgulas decimais
            if (valor_botao == "." && txt_Visor.Text.Contains("."))
            {
                return; // Sai do m�todo sem fazer nada
            }

            txt_Visor.Text += valor_botao; // Adiciona o d�gito ao visor
        }

        // M�todo para calcular o resultado final
        private void CalcularResultado()
        {
            double valor_atual = double.Parse(txt_Visor.Text); // Pega o valor atual do visor

            // Executa a opera��o pendente
            switch (operacao_pendente)
            {
                case "+":
                    valor += valor_atual; // Soma
                    break;
                case "-":
                    valor -= valor_atual; // Subtra��o
                    break;
                case "*":
                    valor *= valor_atual; // Multiplica��o
                    break;
                case "/":
                    if (valor_atual != 0)
                    {
                        valor /= valor_atual; // Divis�o (com verifica��o de zero)
                    }
                    else
                    {
                        MessageBox.Show("N�o � poss�vel dividir por zero!");
                        return; // Sai do m�todo em caso de erro
                    }
                    break;
                default:
                    // Se n�o houver opera��o pendente, usa o valor atual
                    valor = valor_atual;
                    break;
            }

            txt_Visor.Text = valor.ToString(); // Mostra o resultado no visor
            operacao_pendente = "";           // Reseta a opera��o pendente
            resolver_operacao = true;         // Sinaliza para limpar o visor na pr�xima entrada
        }

        // M�todos de clique para os bot�es num�ricos (0-9)
        private void btn_1_Click(object sender, EventArgs e) => funcao_inicial_Botao("1");
        private void btn_2_Click(object sender, EventArgs e) => funcao_inicial_Botao("2");
        private void btn_3_Click(object sender, EventArgs e) => funcao_inicial_Botao("3");
        private void btn_4_Click(object sender, EventArgs e) => funcao_inicial_Botao("4");
        private void btn_5_Click(object sender, EventArgs e) => funcao_inicial_Botao("5");
        private void btn_6_Click(object sender, EventArgs e) => funcao_inicial_Botao("6");
        private void btn_7_Click(object sender, EventArgs e) => funcao_inicial_Botao("7");
        private void btn_8_Click(object sender, EventArgs e) => funcao_inicial_Botao("8");
        private void btn_9_Click(object sender, EventArgs e) => funcao_inicial_Botao("9");
        private void btn_0_Click(object sender, EventArgs e) => funcao_inicial_Botao("0");
        private void btn_virgula_Click(object sender, EventArgs e) => funcao_inicial_Botao(".");

        // M�todo para inverter o sinal do n�mero
        private void btn_negativo_Click(object sender, EventArgs e)
        {
            if (txt_Visor.Text.StartsWith("-")) // Se j� for negativo
            {
                txt_Visor.Text = txt_Visor.Text.Substring(1); // Remove o sinal
            }
            else if (txt_Visor.Text != "0") // Se n�o for zero
            {
                txt_Visor.Text = "-" + txt_Visor.Text; // Adiciona o sinal negativo
            }
        }

        // Limpa apenas o visor (CE)
        private void btn_ce_Click(object sender, EventArgs e)
        {
            txt_Visor.Text = "0";
        }

        // Limpa tudo (C) - visor e opera��o pendente
        private void btn_c_Click(object sender, EventArgs e)
        {
            txt_Visor.Text = "0";
            valor = 0;
            operacao_pendente = "";
        }

        // Apaga o �ltimo d�gito (Backspace)
        private void btn_apagar_Click(object sender, EventArgs e)
        {
            if (txt_Visor.Text.Length > 1) // Se houver mais de um d�gito
            {
                txt_Visor.Text = txt_Visor.Text.Substring(0, txt_Visor.Text.Length - 1); // Remove o �ltimo
            }
            else
            {
                txt_Visor.Text = "0"; // Volta para zero
            }
        }

        // M�todos para as opera��es matem�ticas
        private void btn_divisao_Click(object sender, EventArgs e) => operacao("/");
        private void btn_mult_Click(object sender, EventArgs e) => operacao("*");
        private void btn_sub_Click(object sender, EventArgs e) => operacao("-");
        private void btn_adicao_Click(object sender, EventArgs e) => operacao("+");

        // Bot�o de igual (=) - calcula o resultado
        private void btn_calcular_Click(object sender, EventArgs e)
        {
            if (operacao_pendente != "") // Se houver opera��o pendente
            {
                CalcularResultado(); // Executa o c�lculo
            }
        }
    }
}