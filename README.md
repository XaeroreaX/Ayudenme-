# Ayudenme-
aqui colgare mis problemas







int Song_fileToListText(char path[], ArrayList* playList)
{
    FILE* pFile;

    int returnAux = DENIED;
    char id[101], nombre[101], albun[101], artista[101], visitas[101], duracionSeg[101];
    SSong* music;

    pFile = fopen(path, "r");

    if(playList == NULL || pFile == NULL) return returnAux;

    fgets(nombre, 101, pFile);

    while(!feof(pFile))
    {
        fscanf(pFile, "%[^,],%[^,],%[^,],%[^,],%[^,],%[^\n]\n",id, nombre, albun, artista, visitas, duracionSeg);
        music = Song_contructor(atoi(id), nombre, artista,albun, atoi(duracionSeg));
        music->visit = visitas;

        returnAux = playList->add(playList, music);
    }

    fclose(pFile);

    return returnAux;
}



int Song_listToFileText(char path[], ArrayList* playList)
{
    FILE* pFIle;
    int i, returnAux = DENIED;
    SSong* music;

    pFIle = fopen(path, "w+");

    if(playList == NULL || pFIle == NULL) return returnAux;

    fprintf(pFIle, "id,nombre,albun,artista,visitas,durationSeg\n");

    for(i = 0; i < playList->len(playList); i++)
    {
        music = (SSong*) playList->get(playList, i);
        if(music != NULL)
        {
            fprintf(pFIle, "%d,%s,%s,%s,%d,%d\n", music->id, music->name, music->Albun, music->Artist, music->visit,music->durationSeg);
            returnAux = OK;
        }
    }

    fclose(pFIle);

    return returnAux;
}
