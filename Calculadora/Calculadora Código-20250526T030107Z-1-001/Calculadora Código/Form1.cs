using System;
using System.Windows.Forms;

namespace Aula_4
{
    public partial class Form1 : Form
    {
        
        double valor = 0;               // Armazena o valor acumulado nas operações
        string operacao_pendente = "";  // Guarda a operação (+, -, *, /)
        bool resolver_operacao = false; // Controla quando deve limpar o visor

        public Form1()
        {
            InitializeComponent();  // Método gerado automaticamente que inicializa os componentes do formulário
        }

        private void txt_Visor_TextChanged(object sender, EventArgs e)
        {
            // Evento que ocorre quando o texto no visor é alterado
            // Pode ser usado para validações adicionais
        }

        // Método para tratar operações matemáticas
        public void operacao(String valor_operacao)
        {
            // Se já houver uma operação pendente e não for um novo cálculo
            if (operacao_pendente != "" && !resolver_operacao)
            {
                btn_calcular.PerformClick(); // Executa o cálculo da operação pendente
            }

            valor = double.Parse(txt_Visor.Text); // Converte o valor do visor para double
            operacao_pendente = valor_operacao;   // Armazena a nova operação
            resolver_operacao = true;             // Sinaliza para limpar o visor no próximo número
        }

        // Método para tratar dígitos pressionados
        public void funcao_inicial_Botao(String valor_botao)
        {
            // Se o visor mostrar "0" ou for uma nova operação
            if (txt_Visor.Text == "0" || resolver_operacao == true)
            {
                txt_Visor.Clear();        // Limpa o visor
                resolver_operacao = false; // Reseta o flag(indicador)
            }

            // Impede múltiplas vírgulas decimais
            if (valor_botao == "." && txt_Visor.Text.Contains("."))
            {
                return; // Sai do método sem fazer nada
            }

            txt_Visor.Text += valor_botao; // Adiciona o dígito ao visor
        }

        // Método para calcular o resultado final
        private void CalcularResultado()
        {
            double valor_atual = double.Parse(txt_Visor.Text); // Pega o valor atual do visor

            // Executa a operação pendente
            switch (operacao_pendente)
            {
                case "+":
                    valor += valor_atual; // Soma
                    break;
                case "-":
                    valor -= valor_atual; // Subtração
                    break;
                case "*":
                    valor *= valor_atual; // Multiplicação
                    break;
                case "/":
                    if (valor_atual != 0)
                    {
                        valor /= valor_atual; // Divisão (com verificação de zero)
                    }
                    else
                    {
                        MessageBox.Show("Não é possível dividir por zero!");
                        return; // Sai do método em caso de erro
                    }
                    break;
                default:
                    // Se não houver operação pendente, usa o valor atual
                    valor = valor_atual;
                    break;
            }

            txt_Visor.Text = valor.ToString(); // Mostra o resultado no visor
            operacao_pendente = "";           // Reseta a operação pendente
            resolver_operacao = true;         // Sinaliza para limpar o visor na próxima entrada
        }

        // Métodos de clique para os botões numéricos (0-9)
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

        // Método para inverter o sinal do número
        private void btn_negativo_Click(object sender, EventArgs e)
        {
            if (txt_Visor.Text.StartsWith("-")) // Se já for negativo
            {
                txt_Visor.Text = txt_Visor.Text.Substring(1); // Remove o sinal
            }
            else if (txt_Visor.Text != "0") // Se não for zero
            {
                txt_Visor.Text = "-" + txt_Visor.Text; // Adiciona o sinal negativo
            }
        }

        // Limpa apenas o visor (CE)
        private void btn_ce_Click(object sender, EventArgs e)
        {
            txt_Visor.Text = "0";
        }

        // Limpa tudo (C) - visor e operação pendente
        private void btn_c_Click(object sender, EventArgs e)
        {
            txt_Visor.Text = "0";
            valor = 0;
            operacao_pendente = "";
        }

        // Apaga o último dígito (Backspace)
        private void btn_apagar_Click(object sender, EventArgs e)
        {
            if (txt_Visor.Text.Length > 1) // Se houver mais de um dígito
            {
                txt_Visor.Text = txt_Visor.Text.Substring(0, txt_Visor.Text.Length - 1); // Remove o último
            }
            else
            {
                txt_Visor.Text = "0"; // Volta para zero
            }
        }

        // Métodos para as operações matemáticas
        private void btn_divisao_Click(object sender, EventArgs e) => operacao("/");
        private void btn_mult_Click(object sender, EventArgs e) => operacao("*");
        private void btn_sub_Click(object sender, EventArgs e) => operacao("-");
        private void btn_adicao_Click(object sender, EventArgs e) => operacao("+");

        // Botão de igual (=) - calcula o resultado
        private void btn_calcular_Click(object sender, EventArgs e)
        {
            if (operacao_pendente != "") // Se houver operação pendente
            {
                CalcularResultado(); // Executa o cálculo
            }
        }
    }
}