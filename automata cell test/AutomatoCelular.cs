using UnityEngine;
using System.Collections;
/*controla populacao
 regras:
 vida < 2 vizinhos = morre
 vida > 3 vizinhos = morre
 2 ou 3 vizinhos = sobrevive
 3 vizinhos = ressussita

implementar: imigracao e recursos
*/
public class AutomatoCelular : MonoBehaviour
{
    public int linha = 50;
    public int coluna = 50;
	
    public Transform origem;
    public Celula celula;
	
    Celula [,] populacao;
    bool[,] proximaGeracao;
    bool iniciou = false;
	
	void Start()
	{
	    int x, y;
        int xOffset = 0, yOffset = 0;
        Vector3 pos;

        populacao = new Celula[linha, coluna];
        proximaGeracao = new bool[linha, coluna];   
        
        for ( x = 0; x < linha; x++ )
		{
            for ( y = 0; y < coluna; y++ )
			{
                pos = new Vector3 ( origem.position.x + xOffset, origem.position.y, origem.position.z + yOffset);
                populacao[y, x] = Instantiate( celula, pos, Quaternion.identity ) as Celula;
                proximaGeracao[y, x] = false;
                yOffset++;
            }
            xOffset++;
            yOffset = 0;
        }
		GerarPopulacao();
	}

    void Update()
	{
		if ( Input.GetMouseButtonUp(0) )
			iniciou = !iniciou;

        if ( iniciou )
		{
			// faz a simulacao para uma geracao
       		for ( int y = 0; y < linha; y++ )
			{
	            for ( int x = 0; x < coluna; x++ )
				{
	                //celula viva ou morta
	                bool viva = populacao[y, x].viva;
	                
	                int vizinhos = ContaVizinhos(x, y);
	                
	                // celula viva com menos do que 2 vizinhos vivos morre
	                if ( viva && ( vizinhos < 2 ))
	                    proximaGeracao[y, x] = false;
	                    
	                // celula viva com 2 ou 3 vizinhos vivos sobrevive
	                else if ( viva && ( vizinhos >= 2 && vizinhos <= 3 ))
	                    proximaGeracao[y, x] = true;
	
	                // celula viva com mais do que 3 vizinhos vivos morre
	                else if ( viva && ( vizinhos > 3 ))
	                    proximaGeracao[y, x] = false;
	
	                // celula morta com exatamente 3 vizinhos vivos se reproduz
	                else if ( !viva && ( vizinhos == 3 ))
	                    proximaGeracao[y, x] = true;
	            }
	        }

	        // aplica a regra calculada
	        for ( int y = 0; y < linha; y++ )
	            for ( int x = 0; x < coluna; x++ )
	                if ( proximaGeracao[ y, x ] )
	                    populacao[ y, x ].Nasce();
	                else
	                    populacao[ y, x ].Morre();
		}
    }

    // conta a quantidade de vizinhos vivos de uma celula
    int ContaVizinhos ( int x, int y )
	{
        int vizinhos = 0;
        bool cima, baixo, esq, dir, cimaEsq, cimaDir, baixoEsq, baixoDir; // flags de posicao para checagem de celulas na borda

        esq = (x == 0);                // totalmente na esquerda
        dir = (x == coluna - 1);        // totalmente na direita
        cima = (y == 0);               // totalmente em cima
        baixo = (y == linha - 1);      // totalmente em baixo
        cimaEsq = ( cima && esq );    // canto superior esquerdo
        cimaDir = ( cima && dir );    // canto superior direito
        baixoEsq = ( baixo && esq );    // canto inferior esquerdo
        baixoDir = ( baixo && dir );    // canto inferior direito
        
        if ( cimaEsq )
		{
            if ( populacao[y, x + 1].viva )
				vizinhos++; // direita
            if ( populacao[y + 1, x].viva )
				vizinhos++; // baixo
            if ( populacao[y + 1, x + 1].viva )
				vizinhos++; // baixo + direita
            
            cima = false;
            esq = false;
        }
        else if ( cimaDir)
		{
            if ( populacao[y, x - 1].viva )
				vizinhos++; // esquerda
            if ( populacao[y + 1, x].viva)
				vizinhos++; // baixo
            if ( populacao[y + 1, x - 1].viva )
				vizinhos++; // esquerda + baixo

            cima = false;
            dir = false;
        }
        else if ( baixoEsq )
		{
            if ( populacao[y - 1, x].viva )
				vizinhos++; // cima
            if ( populacao[y, x + 1].viva )
				vizinhos++; // direita
            if ( populacao[y - 1, x + 1].viva )
				vizinhos++; // cima + direita
            
            baixo = false;
            esq = false;
        }
        else if ( baixoDir )
		{
            if ( populacao[y - 1, x].viva )
				vizinhos++; // cima
            if ( populacao[y, x - 1].viva )
				vizinhos++; // esquerda
            if ( populacao[y - 1, x - 1].viva )
				vizinhos++; // cima + esquerda
            
            baixo = false;
            dir = false;
        }
        else if ( esq )
		{
            if ( populacao[y - 1, x].viva )
				vizinhos++; // cima
            if ( populacao[y - 1, x + 1].viva )
				vizinhos++; // cima + direita
            if ( populacao[y, x + 1].viva )
				vizinhos++; // direita
            if ( populacao[y + 1, x].viva )
				vizinhos++; // baixo
            if ( populacao[y + 1, x + 1].viva )
				vizinhos++; // baixo + direita
        }
        else if ( dir )
		{
            if ( populacao[y - 1, x].viva )
				vizinhos++; // cima
            if ( populacao[y - 1, x - 1].viva )
				vizinhos++; // cima + esquerda
            if ( populacao[y, x - 1].viva )
				vizinhos++; // esquerda
            if ( populacao[y + 1, x].viva )
				vizinhos++; // baixo
            if ( populacao[y + 1, x - 1].viva )
				vizinhos++; // baixo + esquerda
        }
        else if ( cima )
		{
            if ( populacao[y, x - 1].viva )
				vizinhos++; // esquerda
            if ( populacao[y, x + 1].viva )
				vizinhos++; // direita
            if ( populacao[y + 1, x].viva )
				vizinhos++; // baixo
            if ( populacao[y + 1, x + 1].viva )
				vizinhos++; // baixo + direita
            if ( populacao[y + 1, x - 1].viva )
				vizinhos++; // baixo + esquerda
        }
        else if ( baixo )
		{
            if ( populacao[y, x - 1].viva )
				vizinhos++; // esquerda
            if ( populacao[y, x + 1].viva )
				vizinhos++; // direita
            if ( populacao[y - 1, x].viva )
				vizinhos++; // cima
            if ( populacao[y - 1, x + 1].viva )
				vizinhos++; // cima + direita
            if ( populacao[y - 1, x - 1].viva )
				vizinhos++; // cima + esquerda
        }
        // celula do meio (nao esta em nenhuma borda)
        else
		{
            if ( populacao[y, x - 1].viva )
				vizinhos++; // esquerda
            if ( populacao[y, x + 1].viva )
				vizinhos++; // direita
            if ( populacao[y - 1, x].viva )
				vizinhos++; // cima
            if ( populacao[y - 1, x - 1].viva )
				vizinhos++; // cima esquerda
            if ( populacao[y - 1, x + 1].viva )
				vizinhos++; // cima direita
            if ( populacao[y + 1, x].viva )
				vizinhos++; // baixo
            if ( populacao[y + 1, x - 1].viva )
				vizinhos++; // baixo esquerda
            if ( populacao[y + 1, x + 1].viva )
				vizinhos++; // baixo direita
        }

        return vizinhos;
    }

    void Limpar()
	{
        for ( int y = 0; y < linha; y++ )
            for ( int x = 0; x < coluna; x++ )
			{
                populacao[y, x].Morre();        
                proximaGeracao[y, x] = false;
            }
    }

    void GerarPopulacao()
	{
        Limpar();
        for ( int y = 0; y < linha; y++ )
            for ( int x = 0; x < coluna; x++ )
                if ( Random.Range ( 0, 2 ) == 1 )
				{
                    populacao[y, x].Nasce();
                    proximaGeracao[y, x] = true;
                }
    }
}
