dotnet aspnet-codegenerator controller \
    -name ClientController \
    -m Client \
    -dc ClientContext \
    -async \
    -api \
    -outDir Controllers

dotnet aspnet-codegenerator controller \
    -name TelphoneController \
    -m Telphone \
    -dc ClientContext \
    -async \
    -api \
    -outDir Controllers

dotnet aspnet-codegenerator controller \
    -name AddressController \
    -m Address \
    -dc ClientContext \
    -async \
    -api \
    -outDir Controllers


        //"ConnectionString": "User ID=postgres;Password=password;Host=localhost;Port=5432;Database=CrudClient;Pooling=true;"  
