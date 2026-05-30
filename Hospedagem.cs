namespace MeuHotel.Models
{
    public class Hospedagem
    {
        public Quarto QuartoSelecionado {  get; set; }
        public int QtdeAdultos { get; set; }
        public int QtdeCriancas { get; set; }
        public DateTime DataCheckIn { get; set; }
        public DateTime DataCheckOut { get; set; }

        public int Estadia
        {
            get => DataCheckOut.Subtract(DataCheckIn).Days;
        }

        public double ValorTotal
        {
            get
            {
                double valor_adultos = QtdeAdultos * QuartoSelecionado.ValorDiariaAdulto;
                double valor_criancas = QtdeCriancas * QuartoSelecionado.ValorDiariaCrianca;

                double total = (valor_adultos + valor_criancas) * Estadia;

                return total;
            }
        }


    }
}
