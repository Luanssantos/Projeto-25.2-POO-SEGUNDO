class Program
{
    static void Main()
    {
        // Cria uma TV de 55 polegadas
        Televisao tv = new Televisao(55);

        // Liga a TV
        tv.Ligar();
        // Mostra o estado da TV (usando o ToString da classe)
        Console.WriteLine(tv);

        // Aumenta o volume duas vezes
        tv.AumentarVolume();
        tv.AumentarVolume();
        // Mostra novamente o estado da TV
        Console.WriteLine(tv);

        // Ativa ou desativa o mudo (nesse caso, ativa)
        tv.AtivarOuDesativarMudo();
        // Mostra o estado da TV (volume aparecerá como 0 porque está mudo)
        Console.WriteLine(tv);

        // Muda para o próximo canal duas vezes
        tv.ProximoCanal();
        tv.ProximoCanal();
        // Mostra o estado da TV (canais aumentaram 2 unidades)
        Console.WriteLine(tv);

        // Vai direto para o canal 520
        tv.IrParaCanal(520);
        // Mostra o estado da TV
        Console.WriteLine(tv);

        // Tenta ir para o próximo canal (como está no máximo, volta para 1)
        tv.ProximoCanal();
        // Mostra o estado da TV
        Console.WriteLine(tv);

        // Desliga a TV (guarda o último canal)
        tv.Desligar();
        // Mostra o estado da TV (deve mostrar "TV desligada")
        Console.WriteLine(tv);

        // Liga a TV novamente (volta para o último canal guardado)
        tv.Ligar();
        // Mostra o estado da TV
        Console.WriteLine(tv);
    }
}