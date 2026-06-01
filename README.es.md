# Titulo

AdminBraziers

## Descripcion Corta

Braseros y jaulas de fuego metalicas enfocadas a administradores para zonas gestionadas del servidor en Vintage Story.

## Descripcion Larga

`AdminBraziers` es un mod decorativo y utilitario para Vintage Story 1.22.x.

Añade braseros y jaulas de fuego metalicas siempre encendidas, pensadas para zonas gestionadas por el servidor como ciudades iniciales, caminos publicos, mercados, posadas, templos, arenas y asentamientos protegidos.

El mod es especialmente util cuando el equipo de administracion quiere fuentes de luz atmosfericas permanentes sin tener que recargar combustible manualmente.

El paquete incluye:

- Braseros metalicos pequeños
- Jaulas de fuego grandes
- Variantes de chatarra, cobre, bronce negro, hierro, hierro meteorico y acero
- Un archivo de configuracion de servidor: `adminbraziers.json`
- Comportamiento opcional solo para administradores en servidores survival

## Modo Admin

El mod incluye un modo admin configurable:

- `adminMode`: activa el comportamiento orientado a administradores.
- `removeCraftingRecipesWhenAdminModeEnabled`: elimina las recetas survival cuando el modo admin esta activado.
- `adminPrivileges`: privilegios que cuentan como admin si las recetas se mantienen pero el modo admin sigue activado.

Con la configuracion por defecto, los jugadores no pueden fabricar estos braseros en survival. El equipo del servidor puede seguir colocandolos usando modo creativo, `/give`, WorldEdit u otras herramientas de administracion.

Por defecto, la comprobacion de permisos usa `root`, que coincide con el rol vanilla `admin`.

## Relacion con Braziers

Este mod esta basado en el mod original `Braziers`:

https://mods.vintagestory.at/braziers

El mod original añade braseros y jaulas de fuego decorativas permanentes.

`AdminBraziers` mantiene ese uso decorativo, pero se centra en zonas gestionadas por el servidor. Añade una identidad de mod separada, un dominio de assets separado y configuracion para convertir estos bloques en elementos solo para administradores eliminando las recetas survival cuando se desee.

Usa el mod original si quieres braseros decorativos normales disponibles para los jugadores mediante crafteo survival. Usa `AdminBraziers` si quieres braseros permanentes controlados por el staff para construcciones publicas o protegidas del servidor.

## Notas Importantes

- El mod debe instalarse tanto en el servidor como en los clientes porque añade bloques y assets.
- No es un mod solo server-side.
- Esta pensado para zonas decorativas creadas por administradores, no como un item survival orientado al realismo.
- Los cambios de recetas requieren reiniciar el servidor despues de editar la configuracion.

## Instrucciones de Uso

1. Instala el mod en el servidor y en los clientes.
2. Arranca el servidor una vez para generar `ModConfig/adminbraziers.json`.
3. Manten `adminMode` activado si los braseros deben ser solo para administradores.
4. Reinicia el servidor despues de cambiar opciones relacionadas con recetas.
5. Coloca los braseros manualmente en zonas gestionadas por el servidor.

Ejemplo de configuracion:

```json
{
  "adminMode": true,
  "removeCraftingRecipesWhenAdminModeEnabled": true,
  "adminPrivileges": [
    "root"
  ]
}
```

Compatibilidad:

- Vintage Story `1.22.x`

## Creditos

- Autor: `spasmos`
- Contribuidores: `Digitalr (Just_a_cat)`, `DazPrinzip`
- Basado en el mod original `Braziers`

## Changelog 1.0.0

- Primera release como `AdminBraziers`
- Renombrada la identidad del proyecto y del mod para evitar confusion con el mod original
- Añadidas notas explicitas de relacion con el mod original `Braziers`
- Añadido el archivo de configuracion `adminbraziers.json`
- Añadido modo opcional solo para administradores eliminando las recetas survival
- Conservado el uso decorativo de braseros y jaulas de fuego permanentes
