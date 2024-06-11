const execSync = require('child_process').execSync;

// console.log("removing generated/openapi directory...");
// execSync('rm -rf ${generatePath}');

const output = execSync('npx @openapitools/openapi-generator-cli generate -g typescript-angular -i src/api/open-api.json -o src/api --additional-properties=usePromises=true',
    { encoding: 'utf-8'}
);
console.log(output);