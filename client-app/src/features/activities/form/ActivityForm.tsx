import React, { useState, useContext, useEffect } from 'react';
import { Segment, Form, Button, Grid } from 'semantic-ui-react';
import {   ActivityFormValues } from '../../../app/models/activity';
import { v4 as uuid } from 'uuid';
import { observer } from 'mobx-react-lite';
import { RouteComponentProps } from 'react-router';
import {Form as FinalForm,Field} from 'react-final-form';
import TextInput from '../../../app/common/form/TextInput';
import SelectInput from '../../../app/common/form/SelectInput';
import TextAreaInput from '../../../app/common/form/TextAreaInput';
import { status } from '../../../app/common/options/statusOptions';
import DateInput from '../../../app/common/form/DateInput';
import { combineDateAndTime } from '../../../app/common/util/util';
import {combineValidators, isRequired, composeValidators, hasLengthGreaterThan} from 'revalidate';
import { RootStoreContext } from '../../../app/stores/rootStore';

interface DetailParams {
  id: string;
}

const validate = combineValidators({
    name : isRequired({message: 'The name is required'}),
    status : isRequired('Status'),
    description : composeValidators (
      isRequired('Description'),
      hasLengthGreaterThan(4)({message : 'Description should contain 5 characters'})
      )(),
    amount : isRequired('Amount'),
    date : isRequired('Date'),
    noOfAcres:isRequired("NoOf Acres"),
    address : isRequired('Address'),
    time : isRequired('Time'),
    phoneNumber:isRequired('Phone Number')

})

const ActivityForm: React.FC<RouteComponentProps<DetailParams>> = ({
  match,
  history
}) => {
  const rootStore = useContext(RootStoreContext);
  const {
    createActivity,
    editActivity,
    submitting,
    loadActivity,
  } = rootStore.activityStore;

  const [activity, setActivity] = useState(new ActivityFormValues());

  const [loading,setLoading] = useState(false);

  useEffect(() => {
    if (match.params.id) {
      setLoading(true);
      loadActivity(match.params.id).then(
        (activity) =>   setActivity(new ActivityFormValues(activity))
      ).finally(() => setLoading(false));
    }
  }, [loadActivity, match.params.id]);

  // const handleSubmit = () => {
  //   if (activity.id.length === 0) {
  //     let newActivity = {
  //       ...activity,
  //       id: uuid()
  //     };
  //     createActivity(newActivity).then(() => history.push(`/activities/${newActivity.id}`))
  //   } else {
  //     editActivity(activity).then(() => history.push(`/activities/${activity.id}`));
  //   }
  // };

  const handleFinalFormSubmit = (values: any) => {
    const dateAndTime = combineDateAndTime(values.date , values.time);
    const {date,time, ...activity} = values;
    activity.date  = dateAndTime
    if (!activity.id) {
        let newActivity = {
           ...activity,
          id: uuid()
         };
         createActivity(newActivity);
        } else {
          editActivity(activity);
       }
     };

     
  

  return (

    <Grid>
      <Grid.Column width={10}>
      <Segment clearing>
      <FinalForm
        validate={validate}
        initialValues = {activity}
        onSubmit={handleFinalFormSubmit}
        render= {({handleSubmit,invalid,pristine}) => (

        <Form onSubmit={handleSubmit} loading={loading}>


        <Field
          name='name'
          placeholder='Name'
          value={activity.name}
          component={TextInput}
        />
        <Field
          component={TextInput}
          name='phoneNumber'
          placeholder='PhoneNumber'
          value={activity.phoneNumber}
        />
        <Field
          component={TextAreaInput}
          name='description'
          rows={3}
          placeholder='Description'
          value={activity.description}
        />
        <Field
          component={TextInput}
          name='address'
          placeholder='Address'
          value={activity.address}
        />
        <Form.Group widths='equal'>
        <Field
          component={DateInput}
          name='date'
          date = {true}
          placeholder='Date'
          value={activity.date}
        />
        <Field
          component={DateInput}
          name='time'
          time={true}
          placeholder='Date'
          value={activity.time}
        />
        </Form.Group>
        
        <Field
          component={TextInput}
          name='noOfAcres'
          placeholder='NOoOfAcres'
          value={activity.noOfAcres}
        />
        <Field
          component={TextInput}
          name='amount'
          placeholder='Amount'
          value={activity.amount}
        />
        <Field
          component={SelectInput}
          options={status}
          name='status'
          placeholder='Status'
          value={activity.status}
        />
        <Button
          loading={submitting}
          disabled = {loading || invalid || pristine}
          floated='right'
          positive
          type='submit'
          content='Submit'
        />
        <Button
          onClick={activity.id ? () => history.push(`/activities/${activity.id}`): () => history.push('/activities')}
          disabled={loading}
          floated='right'
          type='button'
          content='Cancel'
        />
      </Form>

        )}
      />
      
    </Segment>
      </Grid.Column>
    </Grid>
   
  );
};

export default observer(ActivityForm);
