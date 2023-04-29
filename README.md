## Jogo RPG
Este projeto é sobre um jogo RPG (Role-Playing Game) Topdown 2D desenvolvido em Monogmae e C#. O projeto consiste num jogador controlável que se move pelo cenário e dispara projéteis nos inimigos. O objetivo é eliminar o maior número de inimigos possível e aumentar a pontuação.

# Requisitos
- .NET Framework
- Microsoft.Xna.Framework
- Microsoft.Xna.Framework.Graphics
- Microsoft.Xna.Framework.Input
- Microsoft.Xna.Framework.Audio
- Microsoft.Xna.Framework.Media
- Comora

# Funcionalidades
- Controlo do jogador com as setas do teclado
- Disparar projéteis usando a tecla Espaço
- Inimigos que se movem em direção ao jogador
- Colisão entre projéteis e inimigos
- Colisão entre jogador e inimigos
- Animações de sprites para o jogador e inimigos
- Sistema de pontuação
- Música de fundo e efeitos sonoros

# Estrutura do Código
O projeto é dividido em várias classes, cada uma responsável por um aspecto específico do jogo:

1. <b>Game1:</b> Classe principal do jogo que gere a lógica do jogo, atualizações e renderização. Contém a inicialização, carregamento de conteúdo, atualização e métodos de desenho.
2. <b>Player:</b> Classe que gere o personagem controlável pelo jogador. Inclui a atualização da posição, animação e detecção de colisão.
3. <b>Enemy:</b> Classe que gere os inimigos que se movem em direção ao jogador. Inclui a atualização da posição, animação e detecção de colisão.
4. <b>Projectile:</b> Classe que gere os projéteis disparados pelo jogador. Inclui a atualização da posição e detecção de colisão.
5. <b>SpriteManager e SpriteAnimation:</b> Classes que gerem e animam sprites para personagens ou objetos do jogo.
6. <b>Controller:</b> Classe que gere a lógica de criação de inimigos e o tempo entre as criações.
7. <b>MySounds:</b> Classe estática que armazena efeitos sonoros e música de fundo utilizados no jogo.

Como Jogar
- Use as setas do teclado para mover o personagem controlável pelo cenário.
- Pressione a tecla Espaço para disparar projéteis nos inimigos.
- Evite colidir com os inimigos para não perder o jogo.
- Elimine o maior número de inimigos possível para aumentar a sua pontuação.
