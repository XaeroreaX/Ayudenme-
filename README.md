# Ayudenme-
aqui colgare mis problemas







int V_fileToListText(char path[], ArrayList* ventaList)
{
    FILE* pFile;

    int returnAux = DENIED;
    char idVenta[50], nombre[100], codigo[100], idCliente[50];
    sVenta* venta;

    pFile = fopen(path, "r");

    if(ventaList == NULL || pFile == NULL) return returnAux;

    fscanf(pFile, "%[^,],%[^,],%[^,],%[^\n]\n", idVenta, nombre, codigo, idCliente);

    while(!feof(pFile))
    {
        fscanf(pFile, "%[^,],%[^,],%[^,],%[^\n]\n", idVenta, nombre, codigo, idCliente);
        venta = V_contructParamVenta(atoi(idVenta), nombre, codigo, atoi(idCliente));

        returnAux = ventaList->add(ventaList, venta);
    }

    return returnAux;
}

int V_listToFileText(char path[], ArrayList* ventaList)
{
    FILE* pFIle;
    int i, returnAux = DENIED;
    sVenta* venta;

    pFIle = fopen(path, "w+");

    if(ventaList == NULL || pFIle == NULL) return returnAux;

    fprintf(pFIle, "id,nombre,codigo,idCliente\n");

    for(i = 0; i < ventaList->len(ventaList); i++)
    {
        venta = (sVenta*) ventaList->get(ventaList, i);
        if(venta != NULL)
        {
            fprintf(pFIle, "%d,%s,%s,%d\n", venta->idVenta, venta->nombre, venta->codigo, venta->idCliente);
            returnAux = OK;
        }
    }

    return returnAux;
}
