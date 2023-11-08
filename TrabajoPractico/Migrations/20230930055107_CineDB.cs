using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CineDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    GeneroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.GeneroId);
                });

            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    SalaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Capacidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.SalaId);
                });

            migrationBuilder.CreateTable(
                name: "Peliculas",
                columns: table => new
                {
                    PeliculaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sinopsis = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Poster = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Trailer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Genero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peliculas", x => x.PeliculaId);
                    table.ForeignKey(
                        name: "FK_Peliculas_Generos_Genero",
                        column: x => x.Genero,
                        principalTable: "Generos",
                        principalColumn: "GeneroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Funciones",
                columns: table => new
                {
                    FuncionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeliculaId = table.Column<int>(type: "int", nullable: false),
                    SalaId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Horario = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funciones", x => x.FuncionId);
                    table.ForeignKey(
                        name: "FK_Funciones_Peliculas_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "PeliculaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funciones_Salas_SalaId",
                        column: x => x.SalaId,
                        principalTable: "Salas",
                        principalColumn: "SalaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FuncionId = table.Column<int>(type: "int", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => new { x.TicketId, x.FuncionId });
                    table.ForeignKey(
                        name: "FK_Tickets_Funciones_FuncionId",
                        column: x => x.FuncionId,
                        principalTable: "Funciones",
                        principalColumn: "FuncionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_PeliculaId",
                table: "Funciones",
                column: "PeliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_SalaId",
                table: "Funciones",
                column: "SalaId");

            migrationBuilder.CreateIndex(
                name: "IX_Peliculas_Genero",
                table: "Peliculas",
                column: "Genero");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_FuncionId",
                table: "Tickets",
                column: "FuncionId");
            //INSERTAR SALAS
            migrationBuilder.InsertData(
                 table: "Salas",
                 columns: new[] { "Nombre", "Capacidad" },
                 values: new object[] { "Sala Chica", 5 });

            migrationBuilder.InsertData(
                table: "Salas",
                columns: new[] { "Nombre", "Capacidad" },
                values: new object[] { "Sala Media", 15 });

            migrationBuilder.InsertData(
                table: "Salas",
                columns: new[] { "Nombre", "Capacidad" },
                values: new object[] { "Sala Grande", 35 });
            //iNSERTAR GENEROS
            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Nombre" },
                values: new object[] { "Acción" });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Nombre" },
                values: new object[] { "Aventura" });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Nombre" },
                values: new object[] { "Ciencia Ficción" });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Nombre" },
                values: new object[] { "Comedia" });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Nombre" },
                values: new object[] { "Documental" });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Nombre" },
                values: new object[] { "Drama" });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Nombre" },
                values: new object[] { "Fantasía" });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Nombre" },
                values: new object[] { "Musical" });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Nombre" },
                values: new object[] { "Suspenso" });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Nombre" },
                values: new object[] { "Terror" });
            //INSERTAR PELICULAS
            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Poster", "Sinopsis", "Trailer", "Genero" },
                values: new object[]{
                    "Metegol",
                    "https://mir-s3-cdn-cf.behance.net/project_modules/max_1200/b1ceaa10955803.560ee6ac8af18.jpg",
                    "Amadeo es un chico tímido pero virtuoso que deberá enfrentarse al más temible rival sobre el campo de fútbol: el Crack. En su duelo, el protagonista contará con la inestimable ayuda de unos jugadores de futbolín liderados por el Capi.",
                    "https://www.youtube.com/watch?v=A1rBLosVvGY",
                    4});
            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Poster", "Sinopsis", "Trailer", "Genero" },
                values: new object[]{
                    "La monja",
                    "https://tinyurl.com/5e8zjh32",
                    "Años después de su graduación, el fantasma de una sádica monja de su época del instituto aterroriza a las exalumnas de un colegio católico femenino.",
                    "https://www.youtube.com/watch?v=eqVjGwYFVqQ",
                    10});
            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Poster", "Sinopsis", "Trailer", "Genero" },
                values: new object[]{
                    "Rescatando al soldado Ryan",
                    "https://www.themoviedb.org/t/p/w220_and_h330_face/yfExW9uPK4idbUDjRGBlXLbMxRR.jpg",
                    "Después de desembarcar en Normandía, en plena Segunda Guerra Mundial, unos soldados norteamericanos deben arriesgar sus vidas para salvar al soldado James Ryan.",
                    "https://www.youtube.com/watch?v=Z9zZUlvGGD0",
                    6});
            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Poster", "Sinopsis", "Trailer", "Genero" },
                values: new object[]{
                    "Transformers",
                    "https://pics.filmaffinity.com/Transformers-365863398-large.jpg",
                    "El destino de la humanidad está en juego cuando dos razas de robots, los buenos Autobots y los villanos Decepticons, llevan su guerra a la Tierra. Sólo un joven humano, Sam Witwicky puede salvar al mundo de la destrucción total.",
                    "https://www.youtube.com/watch?v=IBCLUy7pB5w",
                    1});
            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Poster", "Sinopsis", "Trailer", "Genero" },
                values: new object[]{
                    "Tron: El legado",
                    "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQHWxkkJ4TlNCqB5tUKuCCUIxjPSphZ0j_GL-RrcnWP&s",
                    "Cuando Sam Flynn, un experto programador de 27 años, investiga la desaparición de su padre, se encuentra un mundo paralelo donde su padre ha vivido durante 25 años. Padre e hijo emprenden un viaje a vida o muerte a través de un universo cibernético.",
                    "https://m.youtube.com/watch?v=6DqUQfWdGRY",
                    3});
            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Poster", "Sinopsis", "Trailer", "Genero" },
                values: new object[]{
                    "Son como niños",
                    "https://tinyurl.com/23s4dveh",
                    "Después de 30 años, cinco amigos se reúnen en una casa del lago para llorar la pérdida de su antiguo entrenador de básquet y vuelven a descubrir la alegría de la niñez.",
                    "https://www.youtube.com/watch?v=zqaggelHu5U",
                    4});
            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Poster", "Sinopsis", "Trailer", "Genero" },
                values: new object[]{
                    "Elvis",
                    "https://pics.filmaffinity.com/Elvis-647942773-large.jpg",
                    "Elvis Presley salta a la fama en la década de 1950, mientras mantiene una relación compleja con su manager, el coronel Tom Parker.",
                    "https://www.youtube.com/watch?v=JoqmHAr3fu8",
                    8});
            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Poster", "Sinopsis", "Trailer", "Genero" },
                values: new object[]{
                    "Diego Maradona",
                    "https://es.web.img2.acsta.net/pictures/19/06/19/17/05/3852697.jpg",
                    "El 5 de julio de 1984, Diego Maradona llegó a Nápoles luego de un pago récord. El futbolista más icónico del mundo y una de las ciudades más apasionadas y peligrosas de Europa conformaron una dupla ideal.",
                    "https://www.youtube.com/watch?v=nE1kCWzciLs",
                    5});
            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Poster", "Sinopsis", "Trailer", "Genero" },
                values: new object[]{
                    "El telefono negro",
                    "https://m.cinesargentinos.com.ar/poster/8768-el-telefono-negro.jpg?1654073429",
                    "Un homicida sádico y enmascarado mantiene a Finney, un niño de 13 años, secuestrado en un sótano incomunicado. A través de un teléfono averiado que hay en la pared, Finney se comunica con otras víctimas del criminal, quienes quieren ayudarlo.",
                    "https://www.youtube.com/watch?v=kQ3EMxTAwXY",
                    9 });
            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Poster", "Sinopsis", "Trailer", "Genero" },
                values: new object[]{
                    "Viaje al centro de la Tierra",
                    "https://es.web.img3.acsta.net/medias/nmedia/18/66/88/98/20250073.jpg",
                    "Un profesor de ciencias y su sobrino se encuentran con criaturas extrañas y tierras desconocidas a medida que viajan por debajo de la superficie de la Tierra.",
                    "https://www.youtube.com/watch?v=C0XcI5V0iFM",
                    2});
            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Poster", "Sinopsis", "Trailer", "Genero" },
                values: new object[]{
                    "Warcraft: el primer encuentro de dos mundos",
                    "https://tinyurl.com/3hh3xr2a",
                    "El pacífico reino de Azeroth está a punto de entrar en guerra contra unos terribles invasores que han dejado su destruido reino para colonizar otro. Dos héroes están a punto de chocar y cambiar el destino de su familia, su pueblo y su hogar.",
                    "https://www.youtube.com/watch?v=fuGRN3dYHKg",
                    7});
            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Poster", "Sinopsis", "Trailer", "Genero" },
                values: new object[]{
                    "La guerra de los mundos",
                    "https://tinyurl.com/4k7c3uur",
                    "Cuando la Tierra es invadida por los alienígenas, Ray Ferrier se ve obligado a luchar por sobrevivir y salvar la vida de su familia.",
                    "https://www.youtube.com/watch?v=vby8BBThG7s",
                    3 });
            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Poster", "Sinopsis", "Trailer", "Genero" },
                values: new object[] {
                    "Harry Potter 20 Aniversario: Regreso a Hogwarts",
                    "https://tinyurl.com/42zyd7cf",
                    "Se celebra el 20º aniversario de la primera película de la franquicia, Harry Potter y la piedra filosofal.",
                    "https://www.youtube.com/watch?v=9BfR76alCpQ",
                    5});
            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Poster", "Sinopsis", "Trailer", "Genero" },
                values: new object[]{
                    "Jhon Wick Otro dia para matar",
                    "https://tinyurl.com/2p9d6e75",
                    "La ciudad de Nueva York se llena de balas cuando John Wick, un exasesino a sueldo, regresa de su retiro para enfrentar a los mafiosos rusos, liderados por Viggo Tarasov, que destruyeron todo aquello que él amaba y pusieron precio a su cabeza.",
                    "https://www.youtube.com/watch?v=C0BMx-qxsP4",
                    1});
            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Poster", "Sinopsis", "Trailer", "Genero" },
                values: new object[]{
                    "The Thing",
                    "https://tinyurl.com/2rf7279x",
                    "Un alienígena que se transforma en otras formas vivientes, invade una base científica de la Antártida.",
                    "https://www.youtube.com/watch?v=JIdw2B6zipc",
                    10});
            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Poster", "Sinopsis", "Trailer", "Genero" },
                values: new object[]{
                    "Rocketman",
                    "https://tinyurl.com/ym8fkaz4",
                    "La trayectoria del artista Elton John, desde sus años como niño prodigio del piano en la Royal Academy of Music hasta llegar a ser una superestrella de fama mundial.",
                    "https://www.youtube.com/watch?v=x-SKB4Y_NT8",
                    8});
            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Poster", "Sinopsis", "Trailer", "Genero" },
                values: new object[]{
                    "Corazon de Leon",
                    "https://tinyurl.com/k75uvt2h",
                    "Una abogada se enfrenta al prejuicio social y sus propias dudas cuando ella empieza a salir con un arquitecto de baja estatura.",
                    "https://www.youtube.com/watch?v=RVoqjRB662E",
                    6});
            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Poster", "Sinopsis", "Trailer", "Genero" },
                values: new object[]{
                    "El aprendiz de brujo",
                    "https://tinyurl.com/5kp64wb4",
                    "Dave se convierte en el protegido renuente de Balthazar y recibe un curso intenso en el arte de la magia; pero mientras él se prepara para ayudar a su maestro a defender Manhattan de un poderoso adversario,.",
                    "https://www.youtube.com/watch?v=NqhPSLt8lJE",
                    7});
            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Poster", "Sinopsis", "Trailer", "Genero" },
                values: new object[]{
                    "El gran pez",
                    "https://tinyurl.com/ytzt6nfv",
                    "El joven William Bloom regresa a su casa para cuidar a su padre enfermo, quien cuenta interminables historias sobre su pasado.",
                    "https://www.youtube.com/watch?v=JZTE078OmZg",
                    2});
            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Poster", "Sinopsis", "Trailer", "Genero" },
                values: new object[] {
                    "Hasta el Limite",
                    "https://tinyurl.com/mr2kxndh",
                    "Un locutor de radio recibe una llamada en vivo de un desconocido que amenaza con matar a su familia. Para salvarlos, debe participar en un juego de supervivencia.",
                    "https://www.youtube.com/watch?v=jwUu4uV8E3A",
                    9 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Funciones");

            migrationBuilder.DropTable(
                name: "Peliculas");

            migrationBuilder.DropTable(
                name: "Salas");

            migrationBuilder.DropTable(
                name: "Generos");
        }
    }
}
