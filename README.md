API desarrollada en .NET 10 LTS para realizar el spin de una slot machine.

## Funcionalidad principal
La API tiene un endpoint protegido con JWT, incluye SlotStoreMock y WalletMock para realizar las pruebas.

### POST /api/slot/spin
Realiza un spint completo:
 - Valida salgo del jugador.
 - Debita la apuesta.
 - Calcula nuevos stops.
 - Genera la matriz visible (4x5)
 - Evalúa líneas de pago
 - Calcula premios
 - Acredita ganancias
 - Guarda el nuevo estado del slot

 ## Autenticación
 La API incluye un endpoint para generar la autenticación con JWT.

 ### POST /api/auth/login.

 ## Ejecutar el proyecto
 Para ejecutar el proyecto lanza los comando dotnet restore y dotnet run y en el navegador abre la URL de localhost http://localhost:5286/swagger/index.html

 Ejecuta el endpoint de autenticación, en el body hay que indicar el playerId 4 y devuelve el token. Úsalo en el apartado de Authorize de Swagger.

 Para realizar un Spin ejecuta el endpoint de la funcionalidad principal, indicando la cantidad de la apuesta en el campo bet.
 Devuelve la matriz de símbolos, los premios obtenidos y el total ganado.

 ## Arquitectura
 - Domain: lógica del slot(Slot.Spin())
 - Application: caso de uso (SpinSlotUseCase)
 - Controllers: controladores
 - Infraestructure: mocks de Wallet y SlotStore
 - Models: DTOs
 - Services: JWT

 ## Test
 Se han implementado test de dominio en los que se comprueban que:
 - Se generan correctamente la matriz de simbolos.
 - LastStop se actualiza tras cada spin.
 - Se lanza excepción cuando la apuesta no es válida.

 Se pueden ejecutar lanzando el comando dotnet test