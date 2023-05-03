# Jogo RPG
Este projeto é sobre um jogo RPG (Role-Playing Game) Topdown 2D desenvolvido em Monogmae e C#. O projeto consiste num jogador controlável que se move pelo cenário e dispara projéteis nos inimigos. O objetivo é eliminar o maior número de inimigos possível e aumentar a pontuação.

## Grupo
- 20115 [Andre Cerqueira](https://github.com/AndreCerqueira)
- 20116 [Nuno Fernandes](https://github.com/NunoIsidoro)
- 25968 [Alexandre Marques](https://github.com/Alexmarques11)

## Requisitos
- .NET Framework
- Microsoft.Xna.Framework
- Microsoft.Xna.Framework.Graphics
- Microsoft.Xna.Framework.Input
- Microsoft.Xna.Framework.Audio
- Microsoft.Xna.Framework.Media
- Comora

## Funcionalidades
- Controlo do jogador com as setas do teclado
- Disparar projéteis usando a tecla Espaço
- Inimigos que se movem em direção ao jogador
- Colisão entre projéteis e inimigos
- Colisão entre jogador e inimigos
- Animações de sprites para o jogador e inimigos
- Sistema de pontuação
- Música de fundo e efeitos sonoros

Como Jogar
- Use as setas do teclado para mover o personagem controlável pelo cenário.
- Pressione a tecla Espaço para disparar projéteis nos inimigos.
- Evite colidir com os inimigos para não perder o jogo.
- Elimine o maior número de inimigos possível para aumentar a sua pontuação.

## Estrutura do Código
O projeto é dividido em várias classes, cada uma responsável por um aspecto específico do jogo:

1. <b>Game1:</b> Classe principal do jogo que gere a lógica do jogo, atualizações e renderização. Contém a inicialização, carregamento de conteúdo, atualização e métodos de desenho.
2. <b>Player:</b> Classe que gere o personagem controlável pelo jogador. Inclui a atualização da posição, animação e detecção de colisão.
3. <b>Enemy:</b> Classe que gere os inimigos que se movem em direção ao jogador. Inclui a atualização da posição, animação e detecção de colisão.
4. <b>Projectile:</b> Classe que gere os projéteis disparados pelo jogador. Inclui a atualização da posição e detecção de colisão.
5. <b>SpriteManager e SpriteAnimation:</b> Classes que gerem e animam sprites para personagens ou objetos do jogo.
6. <b>Controller:</b> Classe que gere a lógica de criação de inimigos e o tempo entre as criações.
7. <b>MySounds:</b> Classe estática que armazena efeitos sonoros e música de fundo utilizados no jogo.

# Análise da Organização das Pastas do Jogo
A organização das pastas do jogo está estruturada da seguinte forma:

- <b>Scripts:</b> Os arquivos de script estão na raiz do projeto, sem uma pasta específica.
- <b>Content:</b> A pasta Content contém todos os assets do jogo.
- <b>Font:</b> A fonte do jogo está localizada diretamente na pasta Content, sem uma pasta específica.
- <b>Inimigo:</b> O spritesheet do inimigo está localizado diretamente na pasta Content, sem uma pasta específica.
- <b>Projétil:</b> O spritesheet do projétil está localizado diretamente na pasta Content, sem uma pasta específica.
- <b>Sounds:</b> A pasta Sounds contém todos os arquivos de som do jogo.
- <b>Player:</b> A pasta Player contém 5 spritesheets, cada um correspondendo a uma animação top-down diferente do personagem controlável pelo jogador.

## Análise do Código
### SpriteManager e SpriteAnimation
Esta secção explicará um script importante de código encontrado no projeto, especificamente relacionado às classes SpriteManager e SpriteAnimation. Estas classes são responsáveis por gerir e animar os sprites para os personagens e objetos do jogo.

### Código
```cs
public class SpriteManager
{
    protected Texture2D Texture;
    public Vector2 Position = Vector2.Zero;
    public Color Color = Color.White;
    public Vector2 Origin;
    public float Rotation = 0f;
    public float Scale = 1f;
    public SpriteEffects SpriteEffect;
    protected Rectangle[] Rectangles;
    protected int FrameIndex = 0;

    public SpriteManager(Texture2D Texture, int frames)
    {
        this.Texture = Texture;
        int width = Texture.Width / frames;
        Rectangles = new Rectangle[frames];

        for (int i = 0; i < frames; i++)
            Rectangles[i] = new Rectangle(i * width, 0, width, Texture.Height);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Texture, Position, Rectangles[FrameIndex], Color, Rotation, Origin, Scale, SpriteEffect, 0f);
    }
}

public class SpriteAnimation : SpriteManager
{
    private float timeElapsed;
    public bool IsLooping = true;
    private float timeToUpdate; //default, you may have to change it
    public int FramesPerSecond { set { timeToUpdate = (1f / value); } }

    public SpriteAnimation(Texture2D Texture, int frames, int fps) : base(Texture, frames) {
        FramesPerSecond = fps;
    }

    public void Update(GameTime gameTime)
    {
        timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
        if (timeElapsed > timeToUpdate)
        {
            timeElapsed -= timeToUpdate;

            if (FrameIndex < Rectangles.Length - 1)
                FrameIndex++;

            else if (IsLooping)
                FrameIndex = 0;
        }
    }

    public void setFrame(int frame)
    {
        FrameIndex = frame;
    }
}
```

### Classe SpriteManager
A classe SpriteManager é a base para gerir os sprites no jogo. Ela possui as seguintes propriedades e métodos:

- <b>Texture:</b> Armazena a textura do sprite.
- <b>Position:</b> A posição do sprite no cenário.
- <b>Color:</b> A cor do sprite.
- <b>Origin:</b> O ponto de origem do sprite.
- <b>Rotation:</b> A rotação do sprite.
- <b>Scale:</b> A escala do sprite.
- <b>SpriteEffect:</b> Efeitos aplicados ao sprite.
- <b>Rectangles:</b> Array de retângulos que representam os frames do sprite.
- <b>FrameIndex:</b> O índice do frame atual do sprite.
O construtor da classe <b>SpriteManager</b> recebe a textura e o número de frames do sprite e calcula a largura de cada frame. Em seguida, ele cria um array de retângulos que representam os frames do sprite.

O método <b>Draw</b> é responsável por desenhar o sprite no ecrã, utilizando o método Draw do objeto SpriteBatch.

### Classe SpriteAnimation
A classe SpriteAnimation é uma subclasse da classe <b>SpriteManager</b> e é responsável pela animação dos sprites. Ela possui as seguintes propriedades e métodos adicionais:

- <b>timeElapsed:</b> Armazena o tempo decorrido desde a última atualização de frame.
- <b>IsLooping:</b> Determina se a animação deve ser executada em loop.
- <b>timeToUpdate:</b> Define o intervalo de tempo entre a atualização dos frames.
- <b>FramesPerSecond:</b> Define a taxa de frames por segundo da animação.
O construtor da classe <b>SpriteAnimation</b> recebe a textura, o número de frames e a taxa de frames por segundo (fps) do sprite animado. Ele chama o construtor da classe base SpriteManager para inicializar as propriedades comuns e define a taxa de frames por segundo da animação.

O método <b>Update</b> é responsável por atualizar o frame atual do sprite animado, tendo em consideração o tempo decorrido e a taxa de frames por segundo. Se a animação atingir o último frame e IsLooping for true, a animação retornará ao primeiro frame.

O método <b>setFrame</b> permite definir manualmente o frame atual da animação.

Em resumo, a combinação das classes <b>SpriteManager</b> e <b>SpriteAnimation</b> permite gerir e animar os sprites de maneira eficiente no projeto do jogo RPG. Elas oferecem uma base sólida para manipular os personagens e objetos do jogo, como o jogador, inimigos e projéteis.

### Player
Esta secção analisará um trecho importante de código encontrado no projeto, relacionado à classe <b>Player</b>. Esta classe é responsável por gerir o personagem controlável pelo jogador, incluindo a atualização da posição, animação e detecção de colisão.

### Código
```cs
class Player
{
    private Vector2 position = new Vector2(500, 300);
    private int speed = 300;
    private Dir direction = Dir.Down;
    private bool isMoving = false;
    private KeyboardState kStateOld = Keyboard.GetState();
    public bool dead = false;

    public SpriteAnimation anim;

    public SpriteAnimation[] animations = new SpriteAnimation[4];

    public Vector2 Position
    {
        get
        {
            return position;
        }
    }
    public void setX(float newX)
    {
        position.X = newX;
    }
    public void setY(float newY)
    {
        position.Y = newY;
    }

    public void Update(GameTime gameTime)
    {
        KeyboardState kState = Keyboard.GetState();
        float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

        isMoving = false;

        if (kState.IsKeyDown(Keys.Right))
        {
            direction = Dir.Right;
            isMoving = true;
        }
        if (kState.IsKeyDown(Keys.Up))
        {
            direction = Dir.Up;
            isMoving = true;
        }
        if (kState.IsKeyDown(Keys.Left))
        {
            direction = Dir.Left;
            isMoving = true;
        }
        if (kState.IsKeyDown(Keys.Down))
        {
            direction = Dir.Down;
            isMoving = true;
        }

        if (kState.IsKeyDown(Keys.Space))
        {
            isMoving = false;
        }

        if (dead)
            isMoving = false;

        if (isMoving)
        {
            switch (direction)
            {
                case Dir.Right:
                    if (position.X < 1275)
                    {
                        position.X += speed * dt;                        
                    }
                    break;
                case Dir.Left:
                    if (position.X > 225)
                    {
                        position.X -= speed * dt;
                    }
                    break;
                case Dir.Down:
                    if (position.Y < 1250)
                    {
                        position.Y += speed * dt;
                    }
                    break;
                case Dir.Up:
                    if (position.Y > 200)
                    {
                        position.Y -= speed * dt;
                    }
                    break;
            }
        }

        anim = animations[(int)direction];

        anim.Position = new Vector2(position.X - 48, position.Y - 48);

        if (kState.IsKeyDown(Keys.Space))
        {
            anim.setFrame(0);
        }
        else if (isMoving)
        {
            anim.Update(gameTime);
        } else
        {
            anim.setFrame(1);
        }

        if (!dead)
        {
            if (kState.IsKeyDown(Keys.Space) && kStateOld.IsKeyUp(Keys.Space))
            {
                Projectile.projectiles.Add(new Projectile(position, direction));
                MySounds.projectileSound.Play(1f, 0.5f, 0f); // volume, pitch, pan(left or right speaker)
            }
        }
        kStateOld = kState;
    }
}
```

A classe <b>Player</b> possui as seguintes propriedades e métodos:

- <b>position:</b> A posição do jogador no cenário.
- <b>speed:</b> A velocidade de movimento do jogador.
- <b>direction:</b> A direção do movimento do jogador.
- <b>isMoving:</b> Indica se o jogador está em movimento.
- <b>kStateOld:</b> Armazena o estado anterior do teclado.
- <b>dead:</b> Indica se o jogador está morto.
- <b>anim:</b> A animação atual do jogador.
- <b>animations:</b> Um array de animações, uma para cada direção.
- <b>Position:</b> Propriedade que retorna a posição atual do jogador.
- <b>setX e setY:</b> Métodos para definir as coordenadas X e Y do jogador.
O método <b>Update</b> é responsável por atualizar a posição, a animação e a detecção de colisão do jogador. Ele recebe um objeto GameTime como parâmetro para controlar o tempo decorrido desde a última atualização.

O método <b>Update</b> realiza as seguintes ações:

1. Obtém o estado atual do teclado.
2. Inicializa a variável isMoving como false.
3. Verifica se as teclas direcionais estão pressionadas e atualiza a direção e o estado de movimento do jogador.
4. Se a tecla Espaço estiver pressionada, o jogador para de se mover.
5. Se o jogador estiver morto, ele não se move.
6. Atualiza a posição do jogador de acordo com a direção e a velocidade, limitando a posição dentro dos limites do cenário.
7. Atualiza a animação do jogador de acordo com a direção e o estado de movimento.
8. Se a tecla Espaço estiver pressionada, o jogador dispara um projétil na direção atual e reproduz o som do projétil.

Em resumo, a classe <b>Player</b> é uma parte crucial do projeto do jogo RPG, pois controla o personagem principal do jogo. Ela oferece uma base sólida para gerir o movimento, a animação e a interação do jogador com o ambiente e os inimigos.

### Projectile
Esta secção analisará outro trecho importante de código encontrado no projeto, relacionado à classe Projectile. Esta classe é responsável por gerir os projéteis disparados pelo jogador, incluindo a atualização da posição e a detecção de colisão.

### Código
```cs
internal class Projectile
{
    public static List<Projectile> projectiles = new List<Projectile>();

    private Vector2 position;
    private int speed = 1000;
    public int radius = 18;
    private Dir direction;
    private bool collided = false;

    public Projectile(Vector2 newPos, Dir newDir)
    {
        position = newPos;
        direction = newDir;
    }

    public Vector2 Position
    {
        get
        {
            return position;
        }
    }

    public bool Collided
    {
        get { return collided; }
        set { collided = value; }
    }

    public void Update(GameTime gameTime)
    {
        float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

        switch (direction)
        {
            case Dir.Right:
                position.X += speed * dt;
                break;
            case Dir.Left:
                position.X -= speed * dt;
                break;
            case Dir.Up:
                position.Y -= speed * dt;
                break;
            case Dir.Down:
                position.Y += speed * dt;
                break;
        }
    }
}
```

A classe <b>Projectile</b> possui as seguintes propriedades e métodos:

- <b>projectiles:</b> Lista estática que armazena todos os projéteis ativos.
- <b>position:</b> A posição do projétil no cenário.
- <b>speed:</b> A velocidade de movimento do projétil.
- <b>radius:</b> O raio de colisão do projétil.
- <b>direction:</b> A direção do movimento do projétil.
- <b>collided:</b> Indica se o projétil colidiu com um inimigo.
- <b>Position:</b> Propriedade que retorna a posição atual do projétil.
- <b>Collided:</b> Propriedade que obtém ou define o valor da colisão.
O construtor <b>Projectile</b> recebe dois parâmetros: newPos, que define a posição inicial do projétil, e newDir, que define a direção do projétil.

O método <b>Update</b> é responsável por atualizar a posição do projétil. Ele recebe um objeto GameTime como parâmetro para controlar o tempo decorrido desde a última atualização.

O método <b>Update</b> realiza as seguintes ações:

1. Calcula o tempo decorrido desde a última atualização.
2. Atualiza a posição do projétil de acordo com a direção e a velocidade.

Em resumo, a classe Projectile desempenha um papel importante no projeto do jogo RPG, pois controla os projéteis disparados pelo jogador. Ela oferece uma base sólida para gerir o movimento dos projéteis e a detecção de colisão com os inimigos.

### Enemy
Agora vamos analisar outro trecho importante de código no projeto, relacionado à classe Enemy. Esta classe é responsável por gerir os inimigos que se movem em direção ao jogador, incluindo a atualização da posição, animação e detecção de colisão.

### Código
```cs
internal class Enemy
{
    public static List<Enemy> enemies = new List<Enemy>();

    private Vector2 position = new Vector2(0, 0);
    private int speed = 150;
    public SpriteAnimation anim;
    public int radius = 30;
    private bool dead = false;

    public Enemy(Vector2 newPos, Texture2D spriteSheet)
    {
        position = newPos;
        anim = new SpriteAnimation(spriteSheet, 10, 6);
    }

    public Vector2 Position
    {
        get { return position; }
    }

    public bool Dead
    {
        get { return dead; }
        set { dead = value; }
    }

    public void Update(GameTime gameTime, Vector2 playerPos, bool isPlayerDead)
    {
        anim.Position = new Vector2(position.X - 48, position.Y - 66);
        anim.Update(gameTime);

        float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (!isPlayerDead)
        {
            Vector2 moveDir = playerPos - position;
            moveDir.Normalize();
            position += moveDir * speed * dt;
        }

    }
}
```

A classe <b>Enemy</b> possui as seguintes propriedades e métodos:

- <b>enemies:</b> Lista estática que armazena todos os inimigos ativos.
- <b>position:</b> A posição do inimigo no cenário.
- <b>speed:</b> A velocidade de movimento do inimigo.
- <b>anim:</b> Objeto SpriteAnimation que controla a animação do inimigo.
- <b>radius:</b> O raio de colisão do inimigo.
- <b>dead:</b> Indica se o inimigo está morto.
- <b>Position:</b> Propriedade que retorna a posição atual do inimigo.
- <b>Dead:</b> Propriedade que obtém ou define o valor da propriedade dead.
O construtor Enemy recebe dois parâmetros: newPos, que define a posição inicial do inimigo, e spriteSheet, que define a imagem usada para a animação do inimigo.

O método <b>Update</b> é responsável por atualizar a posição e animação do inimigo. Ele recebe três parâmetros: um objeto GameTime para controlar o tempo decorrido desde a última atualização, a posição do jogador (playerPos) e um booleano isPlayerDead, que indica se o jogador está morto.

O método <b>Update</b> realiza as seguintes ações:

1. Atualiza a posição do objeto de animação com base na posição do inimigo.
2. Atualiza a animação do inimigo.
3. Calcula o tempo decorrido desde a última atualização.
4. Se o jogador não estiver morto, calcula a direção do movimento do inimigo em relação à posição do jogador, normaliza o vetor resultante e atualiza a posição do inimigo com base na direção, velocidade e tempo decorrido.

Em resumo, a classe Enemy desempenha um papel importante no projeto do jogo RPG, pois controla os inimigos que se movem em direção ao jogador. Ela oferece uma base sólida para gerir a movimentação dos inimigos, animação e detecção de colisão com o jogador e projéteis.

### Controller
Vamos analisar o trecho de código relacionado à classe <b>Controller</b>. Essa classe é responsável por gerir a lógica de criação de inimigos no jogo, controlando o tempo entre cada inimigo gerado e a posição inicial deles no cenário.

### Código
```cs
internal class Controller
{
    public static double timer = 2D;
    public static double maxTime = 2D;
    static Random rand = new Random();

    public static void Update(GameTime gameTime, Texture2D spriteSheet)
    {
        timer -= gameTime.ElapsedGameTime.TotalSeconds;

        if (timer <= 0)
        {
            int side = rand.Next(4);

            switch (side)
            {
                case 0:
                    Enemy.enemies.Add(new Enemy(new Vector2(-500, rand.Next(-500, 2000)), spriteSheet));
                    break;
                case 1:
                    Enemy.enemies.Add(new Enemy(new Vector2(2000, rand.Next(-500, 2000)), spriteSheet));
                    break;
                case 2:
                    Enemy.enemies.Add(new Enemy(new Vector2(rand.Next(-500, 2000), -500), spriteSheet));
                    break;
                case 3:
                    Enemy.enemies.Add(new Enemy(new Vector2(rand.Next(-500, 2000), 2000), spriteSheet));
                    break;
            }

            timer = maxTime;        

            if (maxTime > 0.5)
            {
                maxTime -= 0.05D;
            }
        }
    }
}
```

A classe <b>Controller</b> possui as seguintes propriedades e métodos:

- <b>timer:</b> Um temporizador que controla o tempo até o próximo inimigo ser gerado.
- <b>maxTime:</b> O valor máximo do temporizador.
- <b>rand:</b> Um objeto Random para gerar números aleatórios.
- <b>Update:</b> Método que atualiza a lógica do controlador.
O método <b>Update</b> recebe dois parâmetros: um objeto GameTime para controlar o tempo decorrido desde a última atualização e spriteSheet, que é a imagem usada para a animação dos inimigos.

A lógica do método <b>Update</b> é a seguinte:

1. Decrementa o valor do temporizador com base no tempo decorrido desde a última atualização.
2. Se o temporizador for menor ou igual a zero, será criado um novo inimigo:
3. Gera um número aleatório entre 0 e 3 para determinar o lado do cenário em que o inimigo será criado.
4. Dependendo do valor gerado, cria um novo inimigo em uma posição aleatória fora do limite do cenário e adiciona-o à lista de inimigos.
5. Reinicia o temporizador com o valor de maxTime.
6. Se maxTime for maior que 0,5, decrementa 0,05 para tornar a criação de inimigos progressivamente mais rápida.

Em resumo, a classe Controller é responsável por gerenciar a lógica de criação de inimigos no jogo. Ela controla o tempo entre cada inimigo gerado e a posição inicial deles no cenário, tornando a criação de inimigos progressivamente mais rápida à medida que o jogo avança.
