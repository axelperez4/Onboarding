# OnboardingBE
**Onboarding ILU**

Este repositorio contiene el backend del proyecto. El frontend se encuentra [aquí](https://github.com/axelperez4/OnboardingILU)

- Clean Code: Convención de nombres (pascalCase o CamelCase según variables, métodos, archivos en be como en fe)
- Construcción de prototipos: Prototipos adjuntos hechos en figma. [Visitar en figma](https://www.figma.com/file/P19WyKnF6bXLk30KQYpwcu/Onboarding?type=design&node-id=0%3A1&t=C5EvwowDc6nt2oJJ-1)
- Patrones de diseño: Patrón Modelo Vista Controlador con arquitectura de 3 capas (React, C#/Python y SQL Server respectivamente)
- Estructura de datos: Manejo de listas y diccionarios. Estructuras como listas enlazadas, pilas y colas ya están abstraídas en el lenguaje C#, son inherentes a este.
- C#: Servicio RESTful web con C#, utilizando EF como ORM contra SQL Server.
- Python: Flask y SQLAlchemy utilizados para levantar un microservicio consultando SP de la base de datos y retornando JSON.
- HTML: Inherente a React.
- Javascript: Inherente a React
- React: Frontend desarrollado con esta tecnología. Material UI y DevExtreme utilizados para distintos tipos de componentes. Uso de estados y hooks como useEffect integrados.
- Implementación de microservicios: Microservicio en python con Flask y SQL Alchemy que consulta y ejecuta SPs de la base de datos.
- Serverless: Frontend en AWS S3 como página web estática, fácilmente mantenible y consultable [aquí](http://onboardingapilu.s3-website-us-east-1.amazonaws.com/). Nota: Por el momento, el servidor de ILU encargado de la autenticación bloquea algunas de las peticiones. 
- Optimización de procesos: Herramientas AI utilizadas para tal fin.
- TSQL: Implementación de Stored Procedure para recuperar información importante de onboardings. SP Consumido desde microservicio Python.
- Self Service: Usuario es capaz de mantener maestros como las skills por el mismo, disminuyendo dependencia de ayuda externa.
- Plan de pruebas: Proyecto de pruebas y unit tests ubicados en el proyecto correspondiente dentro del proyecto en C# utilizando las bibliotecas estándar del framework. 
