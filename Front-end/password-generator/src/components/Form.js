import React from 'react';
import { useState, useEffect } from "react";
import Button from '@mui/material/Button';
import IconButton from '@mui/material/IconButton';
import Stack from '@mui/material/Stack';
import Item from '@mui/material/Stack';
import { FormGroup } from '@mui/material';
import { Grid } from '@mui/material';
import { InputAdornment } from '@mui/material';
import TextField from '@mui/material/TextField';
import { AccountCircle } from '@mui/icons-material';
import PasswordIcon from '@mui/icons-material/Password';
import VisibilityIcon from '@mui/icons-material/Visibility';
import { Card } from '@mui/material';
import { Typography } from '@mui/material';
import "./Form.css";

function Form() {

    //   async componentDidMount() {
    //     const response = await fetch('/password');
    //     const body = await response.json();
    //     this.setState({clients: body});
    //   } 
    var password;
      
    async function generatePassword(){


    //const [textInput] = useState('');

    const baseURL = "http://localhost:5232";

    const encodedValue = encodeURIComponent("08dabbe0-a463-408f-8778-26e2ace162b1");
    const res = await fetch(`${baseURL}/password?userId=${encodedValue}`, {
        method: "GET",
        datatype: "json"
      });
      //.then((response) => console.log(response));
        

      const data = await res.json();

      const result = {
        data: data,
        status: res.status,
        statusText: res.statusText,
      };
      console.log(result.statusText);
      password = data['password'];
      console.log(password);

    }

    //   useEffect(() => {
    //     fetch(`/password`)
    //      .then((response) => console.log(response));
    //    }, []);



    const [showPassword, setShowPassword] = useState(false);
    

    return (
        <FormGroup id="page">
            <Grid id="form">
                <Stack spacing={2}>
                    <Item>My password generator</Item>
                    <Item>
                        <div>
                            <AccountCircle className='form-icon' fontSize='large' />
                            <TextField id="user-id"
                                label="User id" variant="outlined"
                                helperText="Enter your id to generate a one time password">
                            </TextField>
                        </div>
                        <div>
                            <Button onClick={generatePassword}>Generate password</Button>
                        </div>
                        <Item>
                            <div>
                                <PasswordIcon className='form-icon' fontSize='large' />
                                <TextField id="password" type={showPassword ? "text" : "password"}
                                    label="Password" variant="outlined"
                                    helperText="Notice that: Password expiers in 30 sec."
                                    InputProps={{
                                        endAdornment: <InputAdornment position="end">
                                            <IconButton onClick={() => setShowPassword(s => !s)} style={{ color: "#a742f5" }} >
                                                <VisibilityIcon/>
                                            </IconButton >
                                        </InputAdornment>,
                                    }}>
                                </TextField>
                            </div>
                            <div>
                                <Button>Login</Button>
                                <Button>Reset</Button>
                            </div>
                            <Card>
                                <Typography sx={{ fontSize: 14 }} color="text.secondary" gutterBottom> Your one time password is:
                                </Typography>
                                <Typography variant="h5" component="div" >
                                    {password}
                                </Typography>
                                <Typography sx={{ mb: 1.5 }} color="text.secondary">Hurry! It expiers in 30 seconds!
                                </Typography>
                            </Card>
                        </Item>
                    </Item>
                </Stack>
            </Grid>
        </FormGroup>
    );
}

export default Form;