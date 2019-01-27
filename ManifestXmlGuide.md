# manifest.xml

manifest.xml is a file that essentially contains overrides for pages and options. This is so that the script can generate the site based on the options it obtains from crawling the game's assemblies, but keeps the user-defined descriptions and text from being erased. This means that the site can be quickly and almost automatically updated when new options are added in updates.

manifest.xml has the following structure:

```xml
<?xml version="1.0" encoding="utf-8"?>
<Sr2XmlDocManifest>
  <README>
    <Head>
        This is where the text at the top of the main page goes.
    </Head>
  </README>
  <PartModifierTypeNameGoesHere childPages="anyChildPages,goHere,commaSeparated">
    <Head>
This text appears at the top of the page. It can be used to describe the usage and purpose of the modifier. If you put any text here, it will override the default title so remember to include a title (for instance, "# InputController").
    </Head>
    <Overrides>
      <optionNameGoesHere type="You can use this to optionally override the Type column.">
        You can use this to optionally override the type column. If blank, the tooltip from the game will be used. If there is no tooltip it will be blank.
      </optionNameGoesHere>
    </Overrides>
    <Customs>
      <optionNameGoesHere type="optionType">
        In here, you can put options that the script missed, because they are not regular options like the rest. The type field is mandatory. This is the description.
      </optionNameGoesHere>
    </Customs>
    <Footer>
      This text will appear beneath the property table. This is for 
    </Footer>
  </PartModifierTypeNameGoesHere>
</Sr2XmlDocManifest>
```