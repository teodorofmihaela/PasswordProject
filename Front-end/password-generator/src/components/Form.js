import Button from '@mui/material/Button';
import Stack from '@mui/material/Stack';
import Item from '@mui/material/Stack';
import { FormGroup } from '@mui/material';
import { Grid } from '@mui/material';
import TextField from '@mui/material/TextField';

function Form(){
return(
    <FormGroup>
        <Grid >
        <Stack spacing={2}>
        <Item><h>My password generator</h></Item>
        <Item>
        <TextField id="user-id" label="User id" variant="outlined"> </TextField>
            <div>
         <Button>Generate password</Button>
        <Button>Reset</Button>
        </div>
        </Item>
      </Stack>
      </Grid>
      </FormGroup>
);
}

export default Form;