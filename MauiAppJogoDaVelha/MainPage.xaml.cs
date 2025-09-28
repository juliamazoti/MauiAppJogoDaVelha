using System;

namespace MauiAppJogoDaVelha
{
    public partial class MainPage : ContentPage
    {
        string vez = "X";

        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            // Evita cliques duplos
            if (!btn.IsEnabled) return;

            btn.IsEnabled = false;
            btn.Text = vez;

            // Alterna a vez
            vez = (vez == "X") ? "O" : "X";

            // Verifica vitória
            string vencedor = VerificarVencedor();
            if (!string.IsNullOrEmpty(vencedor))
            {
                await DisplayAlert("Parabéns!", $"O {vencedor} ganhou!", "OK");
                Zerar();
                return;
            }

            // Verifica empate (deu velha) — todos preenchidos e ninguém ganhou
            if (TabuleiroCompleto())
            {
                await DisplayAlert("Deu velha!", "Ninguém ganhou.", "Recomeçar");
                Zerar();
            }
        } // Fecha método

        // Retorna "X" ou "O" se houver vencedor; caso contrário, string.Empty
        private string VerificarVencedor()
        {
            // Linhas
            if (TodosIguais(btn10, btn11, btn12)) return btn10.Text;
            if (TodosIguais(btn20, btn21, btn22)) return btn20.Text;
            if (TodosIguais(btn30, btn31, btn32)) return btn30.Text;

            // Colunas
            if (TodosIguais(btn10, btn20, btn30)) return btn10.Text;
            if (TodosIguais(btn11, btn21, btn31)) return btn11.Text;
            if (TodosIguais(btn12, btn22, btn32)) return btn12.Text;

            // Diagonais
            if (TodosIguais(btn10, btn21, btn32)) return btn10.Text;
            if (TodosIguais(btn12, btn21, btn30)) return btn12.Text;

            return string.Empty;
        }

        // Confere se três botões têm o mesmo texto (não vazio)
        private bool TodosIguais(Button a, Button b, Button c)
        {
            return !string.IsNullOrWhiteSpace(a.Text)
                && a.Text == b.Text
                && b.Text == c.Text;
        }

        private bool TabuleiroCompleto()
        {
            return !string.IsNullOrWhiteSpace(btn10.Text)
                && !string.IsNullOrWhiteSpace(btn11.Text)
                && !string.IsNullOrWhiteSpace(btn12.Text)
                && !string.IsNullOrWhiteSpace(btn20.Text)
                && !string.IsNullOrWhiteSpace(btn21.Text)
                && !string.IsNullOrWhiteSpace(btn22.Text)
                && !string.IsNullOrWhiteSpace(btn30.Text)
                && !string.IsNullOrWhiteSpace(btn31.Text)
                && !string.IsNullOrWhiteSpace(btn32.Text);
        }

        void Zerar()
        {
            btn10.Text = "";
            btn11.Text = "";
            btn12.Text = "";
            btn20.Text = "";
            btn21.Text = "";
            btn22.Text = "";
            btn30.Text = "";
            btn31.Text = "";
            btn32.Text = "";

            btn10.IsEnabled = true;
            btn11.IsEnabled = true;
            btn12.IsEnabled = true;
            btn20.IsEnabled = true;
            btn21.IsEnabled = true;
            btn22.IsEnabled = true;
            btn30.IsEnabled = true;
            btn31.IsEnabled = true;
            btn32.IsEnabled = true;

            // Opcional: reinicia a vez sempre no X
            vez = "X";
        }
    }
}
