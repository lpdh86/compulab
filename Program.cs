//inicio del juego
//nombre del jugador
string nombre = "Jugador";
Console.WriteLine("Ingrese el nombre del jugador");
nombre = (Console.ReadLine());

Console.WriteLine($"!{nombre}, Te has despertado en una isla desierta!");
Console.WriteLine($"No hay nadie que te ayude y no cuentas con recursos");
Console.WriteLine($"Deberas sobrevivir hasta que alguien te encuentre y te rescate");

// caracteristicas Iniciales
Console.WriteLine("Caracteristicas:");
Random rnd = new Random();
int energia = rnd.Next(60, 76);
int comida = rnd.Next(25, 31);
int agua = rnd.Next(20, 31);

// Imprimir caracteristicas
Console.WriteLine($"Cantidad de Energía: {energia}");
Console.WriteLine($"Cantidad de Comida: {comida}");
Console.WriteLine($"Cantidad de Agua: {agua}");

// Inventario de objetos
Console.WriteLine("Inventario:");
int botellas = 1;
Console.WriteLine($"{botellas} botellas");

int Day = 1;
int descansar = 0;
while(energia > 0 && Day < 11)//condiciones para terminar el juego
{       
    Console.WriteLine($"Dia {Day}");

    //Menu de opciones del dia
    Console.WriteLine($"Que haras para sobrevivir hoy {nombre}");
    Console.WriteLine("Menú\n 1. Buscar Comida\n 2. Buscar Agua\n 3. Descansar\n 4. Explorar la Isla\n Ingrese su opción:");
    string opcion = Console.ReadLine();

// Opciones del Dia   
    switch (opcion)
    {
        case "1":// opcion 1 busqueda de comida
            Console.WriteLine("Buscando Comida....");
            int energiaMen = rnd.Next(5, 15);
            Console.WriteLine($"Menos {energiaMen} de energia");
            energia -= energiaMen;
            Console.WriteLine($"Cantidad de energia: {energia}");

            int comidaEncontrada = rnd.Next(1, 101); // Genera un número entre 1 y 100 para simular la probabilidad de cada comida

           if (comidaEncontrada >= 1 && comidaEncontrada <= 30)//encontrar peces con una probabilidad de 30%
            {
                Console.WriteLine("Has encontrado peces");
                comida += 30;
                Console.WriteLine("Aumentas 30 puntos de comida");
                Console.WriteLine($"Cantidad de Comida: {comida}");
            }
            else if (comidaEncontrada >= 31 && comidaEncontrada <= 80)//encontrar frutas con una probabilidad de 50%
            {
                Console.WriteLine("Has encontrado frutas");
                comida += 25;
                Console.WriteLine("Aumentas 25 puntos de comida");
                Console.WriteLine($"Cantidad de Comida: {comida}");
            }
            else if (comidaEncontrada >= 81 && comidaEncontrada <= 100)//encontrar semillas con una probabilidad de 20%
            {
                Console.WriteLine("Has encontrado semillas");
                comida += 10;
                Console.WriteLine("Aumentas 10 puntos de comida");
                Console.WriteLine($"Cantidad de Comida: {comida}");
            }
        break;

        case "2"://opcion 2 busqueda de agua
            Console.WriteLine("Buscando Agua...");
            int energiaMen2 = rnd.Next(5, 15);
            Console.WriteLine($"Menos {energiaMen2} de energía");
            energia -= energiaMen2;
            Console.WriteLine($"Cantidad de energía: {energia}");

            int AguaEncontrada = rnd.Next(1,101);

            if (AguaEncontrada >= 1 && AguaEncontrada <= 80)//encontrar agua potable con un 80% de probabilidad
            {
                Console.WriteLine("Has encontrado agua potable");
                agua += botellas * 20;
                Console.WriteLine("Aumenta 20 puntos de agua");
                Console.WriteLine($"Agua:{agua}");
            }
            else if (AguaEncontrada >= 81 && AguaEncontrada <= 100)// encontrar agua contaminad con un 20% de probabilidad
            {
                Console.WriteLine("Has encontrado agua contaminada");
                energia -= 10;
                Console.WriteLine("Pierdes 10 puntos de energia");
                Console.WriteLine($"Energia:{energia}");
            }
        break;

        case "3":// opcion 3 descansar
            Console.WriteLine("Descansando....");
            energia += 20;
            Console.WriteLine("Recuperaste energia");
            Console.WriteLine($"Tienes {energia} puntos de energia");
            descansar += 1;
            break;

        case "4"://opcion 4 Explorar la isla
            Console.WriteLine("Explorando la isla....");
            int eventoEncontrado = rnd.Next(1,101);

            if (eventoEncontrado >= 1 && eventoEncontrado <= 30)// Evento de animal salvaje
            {
                Console.WriteLine("!!!CORRE!!!");
                Console.WriteLine("HAS ENCONTRADO UN ANIMAL SALVAJE");
                energia -= 10;
                Console.WriteLine("Has logrado escapar pero no has salido ileso");
                Console.WriteLine($"Pierdes {energia} puntos de energia por el ataque del animal");
            }
            else if (eventoEncontrado >= 81 && eventoEncontrado <= 100)// Evento de terrenos peligrosos
            {
                Console.WriteLine("Te has accidentado");
                energia -= 20;
                Console.WriteLine("Has perdido 20 puntos de energia");
                Console.WriteLine($"Energia: {energia} puntos");
            }
            else if (eventoEncontrado >= 31 && eventoEncontrado <= 80)// evento de encontrar 1 botella
            {
                Console.WriteLine("Has encontrado 1 botella");
                botellas += 1;
                Console.WriteLine($"Tienes {botellas} botellas");
            }
            break;
        
        default:// si no se elije ninguna opcion
            Console.WriteLine($"Opción no válida. Intenta de nuevo {nombre}");
            break;
    }

    // Consumir recursos
    Console.WriteLine("El dia ha finalizado llego el momento de consumir los recursos");

    if (comida >= 20)// Consumo de comida si la comida es suficiente
    {
        Console.WriteLine("Se ha consumido comida");
        comida -= 20;
    }
    else if(comida <= 20)// Consumo de comida si la comida no es suficiente
    {
        Console.WriteLine("No tienes suficiente comida pierdes energia");
        energia -= (20 - comida);
        comida = 0;
    }

    if (agua >= 15)// Consumo de agua si la cantidad de agua es suficiente
    {
        Console.WriteLine("Se ha bebido agua");
        agua -= 15;
    }
    else if (agua >= 15)// Consumo de agua si la cantidad de agua no es suficiente
    {
        Console.WriteLine("No tienes suficiente agua pierdes energia");
        agua -= (20 - agua);
        agua = 0;
    }

    // Mostrar caracteristicas después de cada acción
    Console.WriteLine($"{nombre}Has logrado sobrevivir el día");

    Console.WriteLine("Características:");
    Console.WriteLine($"Cantidad de Energía: {energia}");
    Console.WriteLine($"Cantidad de Comida: {comida}");
    Console.WriteLine($"Cantidad de Agua: {agua}");

    Console.WriteLine("Inventario:");
    Console.WriteLine($"{botellas} botellas");

// Eventos nocturnos
    int eventoN = rnd.Next(1,101);
   if (eventoN >= 1 && eventoN <= 10)//probabilidad normal de que suceda un evento nocturno
   {
        int eventoNoc = rnd.Next(1,101);
        if(eventoNoc >=1 && eventoNoc <= 33)
        {
            Console.WriteLine("ha empezado a llover");// Evento nocturno de lluvia
             agua += botellas * 10;
            Console.WriteLine("has ganado 10 puntos de agua");
        }
        else if(eventoNoc >= 34 && eventoNoc <=66)//Evento nocuturno de animal salvaje
        {
            Console.WriteLine("ha aparecido un animal salvaje !CORREEE!");
            energia -= 10;
            Console.WriteLine("has perdido 10 puntos de energia");
        }
        else if(eventoNoc >= 67 && eventoNoc <=100)// Evento nocturno de frio
        {
            Console.WriteLine("ha empezado a hacer frio");
            energia -= 10;
            Console.WriteLine("has perdido 10 puntos de energia");
        }
   }
   else if (descansar >= 1)// Aumento de probabilidad de un 10% de que suceda un evento nocturno
   {
        if (eventoN >= 1 && eventoN <= 20)
        {
            int eventoNoc = rnd.Next(1,101);
            Console.WriteLine("la probabilidad aumento un 10% mas al descansar");
            if(eventoNoc >=1 && eventoNoc <= 33)
            {
                Console.WriteLine("ha empezado a llover"); // Evento nocturno de lluvia con el aumento de probabilidad
                 agua += botellas * 10;
                Console.WriteLine("has ganado 10 puntos de agua");
            }
                else if(eventoNoc >= 34 && eventoNoc <=66)
            {
                Console.WriteLine("ha aparecido un animal salvaje !CORREEE!");// Evento de animales salvajes con el aumento de probabilidad
                energia -= 10;
                Console.WriteLine("has perdido 10 puntos de energia");
            }
            else if(eventoNoc >= 67 && eventoNoc <=100)
            {
                Console.WriteLine("ha empezado a hacer frio");// Evento nocturno de frio con el aumento de probabilidad
                energia -= 10;
                Console.WriteLine("has perdido 10 puntos de energia");
            }
        }
        descansar -= 1;
    }
    
    Day += 1;// Cambio de dia

}
// Finales del juego
if (energia <= 0)// Condicion para perder el juego
{
    Console.WriteLine("GAME OVER HAS MUERTO");
}
else if (Day == 11)// Condicion para ganar el juego
{
    Console.WriteLine("Has sobrevido los 10 dias");
    Console.WriteLine("GANASTE EL JUEGO");
}