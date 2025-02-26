#BUILD -----------------------------------------------------------------------
# USA l'SDK di .Net 8 per compilare l'app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build


# Directory all'interno dell'immagine Docker che verrà creata
WORKDIR /app


# Copia e ripristino delle dipendenze
COPY *.csproj ./
RUN dotnet restore


#RUNTIME -----------------------------------------------------------------------
# Copia i file da una Directory locale al Container
COPY . ./


# RUN esegue un comando all'interno del Container
#dotnet public: serve a compilare e pubblicarla in una Directory di Output
# -c Release: ottimizzazione del codice per la produzione
# -o /out: indica la destinazione d
# --no-restore : serve a non ripristinare le dipendenze ogni volta


RUN dotnet publish -c Release -o out --no-restore


# Usa l'immagine runtime di Net .8 in modo da avere un'immagine più leggera
#AS runtime (di default: da provare velocità-dimensione)
FROM mcr.microsoft.com/dotnet/sdk:8.0


# Imposta la cartella di lavoro ALL'INTERNO dell'immagine Docker
WORKDIR /app


# Copia i file pubblicati dall'immagine di build al container
COPY --from=build /app/out ./


# Espongo la porta 8080:80
EXPOSE 80


# Prova.dll è il file che verrà eseguito all'avvio del container
ENTRYPOINT ["dotnet", "Prova.dll"]
