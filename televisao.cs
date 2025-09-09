// Declaração da classe Televisao
public class Televisao
{
    // Constantes para limites de volume e canais
    private const int VOL_MIN = 0;       // volume mínimo
    private const int VOL_MAX = 100;     // volume máximo
    private const int CANAL_MIN = 1;     // menor canal possível
    private const int CANAL_MAX = 520;   // maior canal possível

    // Campos privados (armazenam estado interno da TV)
    private int _volume;           // volume atual
    private int _canal;            // canal atual
    private int _ultimoCanal = CANAL_MIN; // armazena o último canal antes de desligar
    private bool _mudo;            // indica se a TV está no modo mudo

    // Construtor da classe (executado quando criamos uma nova TV)
    public Televisao(float tamanho)
    {
        Tamanho = tamanho;      // tamanho da tela definido ao criar a TV
        _volume = 10;           // volume inicial padrão
        _canal = CANAL_MIN;     // canal inicial padrão (1)
    }

    // Propriedades públicas
    public float Tamanho { get; }        // tamanho da TV (só leitura)
    public int Resolucao { get; set; }   // resolução da TV (pode ser alterada)
    public bool Estado { get; private set; } // se a TV está ligada ou desligada (somente interna pode alterar)
    public int Volume => _mudo ? 0 : _volume; // retorna 0 se estiver mudo, senão o volume real
    public int Canal => _canal;          // canal atual
    public bool Mudo => _mudo;           // indica se está no modo mudo

    // Método para ligar a TV
    public void Ligar()
    {
        Estado = true;              // marca a TV como ligada
        _canal = _ultimoCanal;      // canal volta para o último canal assistido
    }

    // Método para desligar a TV
    public void Desligar()
    {
        Estado = false;             // marca a TV como desligada
        _ultimoCanal = _canal;      // guarda o canal atual como último canal
    }

    // Métodos de volume
    public void AumentarVolume()
    {
        if (!Estado) return;        // não faz nada se a TV estiver desligada
        if (_mudo) _mudo = false;  // se estiver mudo, desativa o mudo

        if (_volume < VOL_MAX)      // só aumenta se não estiver no máximo
            _volume++;
        else
            Console.WriteLine("Volume já está no máximo.");
    }

    public void DiminuirVolume()
    {
        if (!Estado) return;        // não faz nada se a TV estiver desligada
        if (_mudo) _mudo = false;  // se estiver mudo, desativa o mudo

        if (_volume > VOL_MIN)      // só diminui se não estiver no mínimo
            _volume--;
        else
            Console.WriteLine("Volume já está no mínimo.");
    }

    // Alterna entre mudo e volume normal
    public void AtivarOuDesativarMudo()
    {
        if (!Estado) return;        // não faz nada se desligada
        _mudo = !_mudo;             // troca entre verdadeiro e falso
    }

    // Métodos de canal
    public void ProximoCanal()
    {
        if (!Estado) return;        // não faz nada se desligada
        if (_canal < CANAL_MAX)     // aumenta canal se não estiver no máximo
            _canal++;
        else
            _canal = CANAL_MIN;     // se estiver no máximo, volta para o canal 1 (circular)
    }

    public void CanalAnterior()
    {
        if (!Estado) return;        // não faz nada se desligada
        if (_canal > CANAL_MIN)     // diminui canal se não estiver no mínimo
            _canal--;
        else
            _canal = CANAL_MAX;     // se estiver no mínimo, vai para o canal máximo (circular)
    }

    public void IrParaCanal(int canal)
    {
        if (!Estado) return;        // não faz nada se desligada
        if (canal >= CANAL_MIN && canal <= CANAL_MAX)
            _canal = canal;         // se o canal for válido, muda para ele
        else
            Console.WriteLine($"Canal inválido! Digite entre {CANAL_MIN} e {CANAL_MAX}.");
    }

    // Método ToString para exibir informações da TV
    public override string ToString()
    {
        return Estado
            ? $"TV ligada | Canal: {Canal} | Volume: {Volume} {(Mudo ? "(Mudo)" : "")}"
            : "TV desligada";
    }
}